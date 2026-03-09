using System.Collections;
using UnityEngine;
using VReqDV;

namespace Version_4
{
    // ====================================================================
    // CinemaRunner: A MonoBehaviour helper that enables coroutines and
    // on-screen HUD messages from the static UserAlgorithms class.
    // ====================================================================
    public class CinemaRunner : MonoBehaviour
    {
        private static CinemaRunner _instance;
        public static CinemaRunner Instance
        {
            get
            {
                if (_instance == null)
                {
                    var go = new GameObject("[CinemaRunner_V4]");
                    _instance = go.AddComponent<CinemaRunner>();
                    DontDestroyOnLoad(go);
                }
                return _instance;
            }
        }

        // HUD state
        private static string _hudMessage = "";
        private static Color  _hudColor   = Color.white;
        private static float  _hudTimer   = 0f;

        public static void ShowHUD(string msg, float duration = 3f, Color? color = null)
        {
            _hudMessage = msg;
            _hudTimer   = duration;
            _hudColor   = color ?? Color.white;
        }

        private void Update()
        {
            if (_hudTimer > 0f) _hudTimer -= Time.deltaTime;
            else _hudMessage = "";
        }

        private void OnGUI()
        {
            if (string.IsNullOrEmpty(_hudMessage)) return;

            GUIStyle box = new GUIStyle(GUI.skin.box) { fontSize = 20, alignment = TextAnchor.MiddleCenter };
            box.normal.textColor = _hudColor;

            float w = 520f, h = 56f;
            float x = (Screen.width  - w) * 0.5f;
            float y = Screen.height - 80f;
            GUI.Box(new Rect(x, y, w, h), _hudMessage, box);
        }
    }

    // ====================================================================
    // UserAlgorithms – Version_4 (VR Cinema)
    // ====================================================================
    public static class UserAlgorithms
    {
        // ----------------------------------------------------------------
        // Global cinema state flags
        // ----------------------------------------------------------------
        private static bool _hasTicket  = false;
        private static bool _hasPopcorn = false;
        private static AudioSource _ambientSource;

        // Tracks occupied status for SeatLeft & SeatRight.
        // We CANNOT use StateAccessor for these because their state storage
        // dictionary is never initialized (no VReqDV behavior is attached to them).
        private static readonly System.Collections.Generic.HashSet<string>
            _extraOccupiedSeats = new System.Collections.Generic.HashSet<string>();

        // Shortcut to the runner (creates it on first use)
        private static CinemaRunner Runner => CinemaRunner.Instance;

        // ================================================================
        // HELPERS
        // ================================================================

        /// <summary>Left-click raycast against a named GameObject.</summary>
        private static bool IsObjectClicked(string objectName)
        {
            if (!Input.GetMouseButtonDown(0)) return false;
            if (Camera.main == null) return false;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out RaycastHit hit)) return false;
            GameObject target = GameObject.Find(objectName);
            return target != null && hit.collider.gameObject == target;
        }

        /// <summary>Set a material colour on any named scene object.</summary>
        private static void SetColor(string objectName, Color c)
        {
            GameObject go = GameObject.Find(objectName);
            if (go == null) return;
            Renderer rend = go.GetComponent<Renderer>();
            if (rend != null) rend.material.color = c;
        }

        /// <summary>Fade ALL directional lights + ambient to a target over time.</summary>
        private static IEnumerator FadeLighting(Color ambientTarget, float dirTarget, float duration)
        {
            Color  ambientStart = RenderSettings.ambientLight;
            Light[] dirs = Object.FindObjectsOfType<Light>();
            float startIntensity = dirs.Length > 0 ? dirs[0].intensity : 1f;

            float t = 0f;
            while (t < 1f)
            {
                t += Time.deltaTime / duration;
                float s = Mathf.SmoothStep(0f, 1f, t);
                RenderSettings.ambientLight = Color.Lerp(ambientStart, ambientTarget, s);
                foreach (Light l in dirs)
                    if (l.type == LightType.Directional)
                        l.intensity = Mathf.Lerp(startIntensity, dirTarget, s);
                yield return null;
            }
        }

        /// <summary>Ensure an AudioSource lives on the main camera.</summary>
        private static void InitAudio()
        {
            if (_ambientSource != null) return;
            if (Camera.main == null) return;
            _ambientSource = Camera.main.GetComponent<AudioSource>()
                          ?? Camera.main.gameObject.AddComponent<AudioSource>();
            _ambientSource.loop   = true;
            _ambientSource.volume = 0.12f;
        }

        // ================================================================
        // TICKET MACHINE
        // ================================================================

        public static bool IsTicketMachineClicked()
            => IsObjectClicked("TicketMachine");

        public static void DispenseTicket()
        {
            _hasTicket = true;
            SetColor("TicketMachine", new Color(0.1f, 0.8f, 0.25f));

            GameObject machine = GameObject.Find("TicketMachine");
            if (machine != null)
            {
                // Spawn animated ticket flying out of the machine
                Runner.StartCoroutine(SpawnTicketVisual(machine.transform.position));
                StateAccessor.SetState("TicketMachine", "Dispensed", machine, "Version_4");
            }

            CinemaRunner.ShowHUD("  Ticket Dispensed!  Head to the Theater Door.", 4f, Color.yellow);
            Debug.Log("[Cinema] Ticket dispensed.");
        }

        private static IEnumerator SpawnTicketVisual(Vector3 origin)
        {
            // Create a small yellow card
            GameObject ticket = GameObject.CreatePrimitive(PrimitiveType.Cube);
            ticket.name = "TicketVisual_V4";
            ticket.transform.localScale = new Vector3(0.35f, 0.18f, 0.02f);
            ticket.transform.position   = origin + Vector3.up * 1.3f;

            Renderer r = ticket.GetComponent<Renderer>();
            if (r != null) r.material.color = new Color(1f, 0.92f, 0.15f);

            // Destroy any collider so it doesn't interfere
            Object.Destroy(ticket.GetComponent<BoxCollider>());

            // Animate arc upward then settle in player's hand
            Vector3 start = ticket.transform.position;
            Vector3 end   = start + new Vector3(0.7f, 0.6f, -0.4f);
            float t = 0f;
            while (t < 1f)
            {
                t += Time.deltaTime * 1.1f;
                ticket.transform.position = Vector3.Lerp(start, end, Mathf.SmoothStep(0, 1, t));
                ticket.transform.Rotate(0, 200f * Time.deltaTime, 0);
                yield return null;
            }

            yield return new WaitForSeconds(2.5f);
            Object.Destroy(ticket);
        }

        // ================================================================
        // POPCORN STAND
        // ================================================================

        public static bool IsStandClicked()
            => IsObjectClicked("PopcornStand");

        public static void ServePopcorn()
        {
            _hasPopcorn = true;
            SetColor("PopcornStand", new Color(1f, 0.72f, 0.1f)); // golden

            GameObject stand = GameObject.Find("PopcornStand");
            if (stand != null)
                StateAccessor.SetState("PopcornStand", "Serving", stand, "Version_4");

            Runner.StartCoroutine(PopcornPopEffect());
            CinemaRunner.ShowHUD("  Enjoy your popcorn! ", 3f, new Color(1f, 0.8f, 0f));
            Debug.Log("[Cinema] Popcorn served.");
        }

        private static IEnumerator PopcornPopEffect()
        {
            // Briefly scale the stand up then back to simulate a "pop"
            GameObject stand = GameObject.Find("PopcornStand");
            if (stand == null) yield break;

            Vector3 orig  = stand.transform.localScale;
            Vector3 burst = orig * 1.15f;

            float t = 0f;
            while (t < 1f)
            {
                t += Time.deltaTime * 4f;
                stand.transform.localScale = Vector3.Lerp(orig, burst, Mathf.Sin(t * Mathf.PI));
                yield return null;
            }
            stand.transform.localScale = orig;
        }

        // ================================================================
        // THEATER DOOR
        // ================================================================

        /// <summary>Returns true when the player has a ticket.
        /// Shows a HUD warning if they don't.</summary>
        public static bool CheckHasTicket()
        {
            if (!_hasTicket)
                CinemaRunner.ShowHUD("  Buy a ticket first!", 2.5f, Color.red);
            return _hasTicket;
        }

        public static bool IsDoorClicked(GameObject obj)
            => IsObjectClicked(obj.name);

        public static void UnlockTheaterDoor(GameObject obj)
        {
            SetColor("TheaterDoor", new Color(1f, 0.85f, 0f)); // amber = unlocked
            StateAccessor.SetState("TheaterDoor", "Unlocked", obj, "Version_4");
            CinemaRunner.ShowHUD("  Door Unlocked!  Click the door to enter.", 3.5f, Color.yellow);
            Debug.Log("[Cinema] Door unlocked.");
        }

        public static void OpenTheaterDoor(GameObject obj)
        {
            Runner.StartCoroutine(SlideDoorOpen(obj));
            StateAccessor.SetState("TheaterDoor", "Open", obj, "Version_4");
            CinemaRunner.ShowHUD("  Welcome to the Cinema!", 3f, Color.green);
            Debug.Log("[Cinema] Door opening.");
        }

        private static IEnumerator SlideDoorOpen(GameObject door)
        {
            Renderer rend = door.GetComponent<Renderer>();
            if (rend != null) rend.material.color = new Color(0.1f, 0.85f, 0.1f);

            Vector3 start  = door.transform.position;
            Vector3 target = start + new Vector3(0f, 3.5f, 0f);

            float t = 0f;
            while (t < 1f)
            {
                t += Time.deltaTime * 1.4f; // ~0.7 s slide
                door.transform.position = Vector3.Lerp(start, target, Mathf.SmoothStep(0f, 1f, t));
                yield return null;
            }
        }

        // ================================================================
        // MOVIE SELECTION PANEL
        // ================================================================

        public static bool IsActionSelected()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) { Debug.Log("[Cinema] Action selected."); return true; }
            return false;
        }

        public static bool IsHorrorSelected()
        {
            if (Input.GetKeyDown(KeyCode.Alpha2)) { Debug.Log("[Cinema] Horror selected."); return true; }
            return false;
        }

        public static bool IsSciFiSelected()
        {
            if (Input.GetKeyDown(KeyCode.Alpha3)) { Debug.Log("[Cinema] Sci-Fi selected."); return true; }
            return false;
        }

        public static void SetActionMode(GameObject obj)
        {
            SetColor("MovieSelectionPanel", new Color(1f, 0.45f, 0f)); // orange
            AudioListener.volume = 1.0f; // Surround sound: max volume
            StateAccessor.SetState("MovieSelectionPanel", "Action", obj, "Version_4");
            CinemaRunner.ShowHUD("  ACTION MODE  – Surround Sound On!", 3f, new Color(1f, 0.5f, 0f));
        }

        public static void SetHorrorMode(GameObject obj)
        {
            SetColor("MovieSelectionPanel", new Color(0.5f, 0f, 0f)); // dark red
            StateAccessor.SetState("MovieSelectionPanel", "Horror", obj, "Version_4");
            CinemaRunner.ShowHUD("  HORROR MODE  – Dare to watch…", 3f, Color.red);
        }

        public static void SetSciFiMode(GameObject obj)
        {
            SetColor("MovieSelectionPanel", new Color(0f, 0.35f, 1f)); // blue
            StateAccessor.SetState("MovieSelectionPanel", "Scifi", obj, "Version_4");
            CinemaRunner.ShowHUD("  SCI-FI MODE  – Ambient Blue Glow!", 3f, new Color(0.3f, 0.6f, 1f));
        }

        // ================================================================
        // LIGHTING PANEL
        // ================================================================

        public static bool IsLightingPanelClicked()
            => IsObjectClicked("LightingPanel");

        public static void CycleLighting(GameObject obj)
        {
            bool isBright = StateAccessor.IsState("LightingPanel", "Bright", obj, "Version_4");
            bool isDim    = StateAccessor.IsState("LightingPanel", "Dim",    obj, "Version_4");

            if (isBright)
            {
                Runner.StartCoroutine(FadeLighting(new Color(0.32f, 0.32f, 0.32f), 0.35f, 1.2f));
                StateAccessor.SetState("LightingPanel", "Dim", obj, "Version_4");
                CinemaRunner.ShowHUD("  Lighting: DIM", 2f, Color.cyan);
            }
            else if (isDim)
            {
                Runner.StartCoroutine(FadeLighting(new Color(0.03f, 0.03f, 0.05f), 0.05f, 1.2f));
                StateAccessor.SetState("LightingPanel", "Dark", obj, "Version_4");
                CinemaRunner.ShowHUD("  Lighting: DARK", 2f, Color.gray);
            }
            else
            {
                Runner.StartCoroutine(FadeLighting(Color.white, 1f, 1.2f));
                StateAccessor.SetState("LightingPanel", "Bright", obj, "Version_4");
                CinemaRunner.ShowHUD("  Lighting: BRIGHT", 2f, Color.white);
            }
        }

        // ================================================================
        // SEAT  –  Seat is the sole VReqDV actor.
        //          SeatLeft & SeatRight are handled entirely in C#.
        // ================================================================

        // Tracks which of the 3 seats the player actually clicked.
        private static string _lastClickedSeat = "Seat";

        /// <summary>
        /// Checks if the player clicked ANY of the 3 seats.
        /// Stores which one was clicked in _lastClickedSeat.
        /// Called by the VReqDV behavior with obj = Seat (the sole actor).
        /// </summary>
        public static bool IsSeatClicked(GameObject obj)
        {
            if (!Input.GetMouseButtonDown(0)) return false;
            if (Camera.main == null) return false;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out RaycastHit hit)) return false;

            string[] seatNames = { "Seat", "SeatLeft", "SeatRight" };
            foreach (string n in seatNames)
            {
                GameObject seat = GameObject.Find(n);
                if (seat != null && hit.collider.gameObject == seat)
                {
                    // For Seat: check via StateAccessor (initialized by VReqDV).
                    // For SeatLeft/SeatRight: check our C# HashSet.
                    bool isEmpty = (n == "Seat")
                        ? StateAccessor.IsState(n, "Empty", seat, "Version_4")
                        : !_extraOccupiedSeats.Contains(n);

                    if (isEmpty)
                    {
                        _lastClickedSeat = n;
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Sits the player in whichever seat was last clicked.
        /// Also marks the proxy Seat as Occupied so the VReqDV state
        /// machine doesn't re-trigger the SitDown behavior.
        /// </summary>
        public static void SitOnSeat(GameObject obj)
        {
            string targetName = _lastClickedSeat;
            GameObject targetSeat = GameObject.Find(targetName) ?? obj;

            SetColor(targetName, new Color(0.15f, 0.25f, 0.9f)); // blue = occupied
            Runner.StartCoroutine(SmoothCameraToSeat(targetSeat));

            // Set state on the actual clicked seat.
            // For Seat: use StateAccessor (VReqDV-managed).
            // For SeatLeft/SeatRight: use our C# HashSet (StateAccessor not safe).
            if (targetName == "Seat")
            {
                StateAccessor.SetState("Seat", "Occupied", targetSeat, "Version_4");
            }
            else
            {
                _extraOccupiedSeats.Add(targetName);
                // Also mark proxy Seat as Occupied so the VReqDV precondition
                // (Self.state == empty) stops re-firing.
                GameObject proxySeat = GameObject.Find("Seat");
                if (proxySeat != null)
                    StateAccessor.SetState("Seat", "Occupied", proxySeat, "Version_4");
            }

            string snack = _hasPopcorn ? "  Enjoy your popcorn!  " : "";
            CinemaRunner.ShowHUD($"{snack}Seated! Press [1] Action  [2] Horror  [3] Sci-Fi", 5f, Color.cyan);
        }

        private static IEnumerator SmoothCameraToSeat(GameObject seat)
        {
            Camera cam = Camera.main;
            if (cam == null) yield break;

            Vector3    startPos = cam.transform.position;
            Quaternion startRot = cam.transform.rotation;
            // Position camera just above the seat, looking toward the screen
            Vector3    targetPos = seat.transform.position + new Vector3(0, 1.15f, 0);
            Quaternion targetRot = Quaternion.LookRotation(Vector3.forward, Vector3.up);

            float t = 0f;
            while (t < 1f)
            {
                t += Time.deltaTime * 1.5f;
                float s = Mathf.SmoothStep(0f, 1f, t);
                cam.transform.position = Vector3.Lerp(startPos, targetPos, s);
                cam.transform.rotation = Quaternion.Slerp(startRot, targetRot, s);
                yield return null;
            }
        }

        // ================================================================
        // CINEMA SCREEN
        // ================================================================

        /// <summary>True if any of the 3 seats is occupied.</summary>
        public static bool IsAnySeatOccupied()
        {
            // Check center seat via StateAccessor (VReqDV-managed).
            GameObject centerSeat = GameObject.Find("Seat");
            if (centerSeat != null &&
                StateAccessor.IsState("Seat", "Occupied", centerSeat, "Version_4"))
                return true;

            // Check SeatLeft & SeatRight via C# HashSet (StateAccessor not safe).
            return _extraOccupiedSeats.Count > 0;
        }

        /// <summary>True if a movie mode is chosen (not idle).</summary>
        public static bool IsMovieModeSelected()
        {
            GameObject panel = GameObject.Find("MovieSelectionPanel");
            if (panel == null) return false;
            return StateAccessor.IsState("MovieSelectionPanel", "Action", panel, "Version_4")
                || StateAccessor.IsState("MovieSelectionPanel", "Horror", panel, "Version_4")
                || StateAccessor.IsState("MovieSelectionPanel", "Scifi",  panel, "Version_4");
        }

        public static void PlayMovie(GameObject obj)
        {
            Runner.StartCoroutine(ScreenFlickerOn(obj));
            StateAccessor.SetState("CinemaScreen", "Playing", obj, "Version_4");
            InitAudio();
            CinemaRunner.ShowHUD("  Movie Starting…", 3f, Color.white);
            Debug.Log("[Cinema] Movie started.");
        }

        private static IEnumerator ScreenFlickerOn(GameObject screen)
        {
            Renderer rend = screen.GetComponent<Renderer>();
            if (rend == null) yield break;

            // Flicker effect: 5 rapid on/off flashes
            for (int i = 0; i < 5; i++)
            {
                rend.material.color = Color.white;
                yield return new WaitForSeconds(0.07f);
                rend.material.color = Color.black;
                yield return new WaitForSeconds(0.07f);
            }

            // Steady on with emission glow
            rend.material.color = Color.white;
            rend.material.EnableKeyword("_EMISSION");
            rend.material.SetColor("_EmissionColor", new Color(0.75f, 0.75f, 0.75f));
        }

        // ================================================================
        // AUTO-DIM LIGHTS
        // ================================================================

        /// <summary>True when Action or Horror mode is active (needs auto-dim).</summary>
        public static bool IsDimModeNeeded()
        {
            GameObject panel = GameObject.Find("MovieSelectionPanel");
            if (panel == null) return false;
            return StateAccessor.IsState("MovieSelectionPanel", "Action", panel, "Version_4")
                || StateAccessor.IsState("MovieSelectionPanel", "Horror", panel, "Version_4");
        }

        public static void DimLightsForMovie(GameObject obj)
        {
            Runner.StartCoroutine(FadeLighting(new Color(0.22f, 0.22f, 0.22f), 0.2f, 2.0f));
            StateAccessor.SetState("LightingPanel", "Dim", obj, "Version_4");
            Debug.Log("[Cinema] Lights auto-dimmed for movie.");
        }

        // ================================================================
        // HORROR LIGHTING (red glow, slow fade)
        // ================================================================

        public static void SetHorrorLighting(GameObject obj)
        {
            Runner.StartCoroutine(FadeLighting(new Color(0.5f, 0f, 0.02f), 0.08f, 1.8f));
            StateAccessor.SetState("LightingPanel", "Dark", obj, "Version_4");
            CinemaRunner.ShowHUD("  Horror Lighting Active…", 3f, Color.red);
        }

        // ================================================================
        // SCI-FI LIGHTING (blue ambient glow, slow fade)
        // ================================================================

        public static void SetSciFiLighting(GameObject obj)
        {
            Runner.StartCoroutine(FadeLighting(new Color(0f, 0.13f, 0.72f), 0.12f, 1.8f));
            StateAccessor.SetState("LightingPanel", "Dim", obj, "Version_4");
            CinemaRunner.ShowHUD("  Sci-Fi Blue Glow Active!", 3f, new Color(0.3f, 0.6f, 1f));
        }

        // ================================================================
        // RESET / EXIT
        // ================================================================

        /// <summary>Player presses Escape while seated to vacate.</summary>
        public static bool IsSeatVacated(GameObject obj)
            => Input.GetKeyDown(KeyCode.Escape);

        /// <summary>Full theater reset: screen off, mode idle, lights bright, all seats empty.</summary>
        public static void ResetTheater()
        {
            // --- Screen off ---
            GameObject screen = GameObject.Find("CinemaScreen");
            if (screen != null)
            {
                Renderer r = screen.GetComponent<Renderer>();
                if (r != null)
                {
                    r.material.color = Color.black;
                    r.material.DisableKeyword("_EMISSION");
                }
                StateAccessor.SetState("CinemaScreen", "Off", screen, "Version_4");
            }

            // --- Panel idle ---
            GameObject panel = GameObject.Find("MovieSelectionPanel");
            if (panel != null)
            {
                SetColor("MovieSelectionPanel", new Color(0.45f, 0.45f, 0.45f));
                StateAccessor.SetState("MovieSelectionPanel", "Idle", panel, "Version_4");
            }

            // --- Lights bright (instant snap on reset) ---
            Runner.StartCoroutine(FadeLighting(Color.white, 1f, 1.0f));
            GameObject lighting = GameObject.Find("LightingPanel");
            if (lighting != null)
                StateAccessor.SetState("LightingPanel", "Bright", lighting, "Version_4");

            // --- All 3 seats empty ---
            // Center seat: reset via StateAccessor.
            GameObject centerSeat = GameObject.Find("Seat");
            if (centerSeat != null)
            {
                SetColor("Seat", new Color(0.55f, 0.3f, 0.1f));
                StateAccessor.SetState("Seat", "Empty", centerSeat, "Version_4");
            }
            // SeatLeft & SeatRight: reset via HashSet + visual only.
            foreach (string n in new[] { "SeatLeft", "SeatRight" })
            {
                SetColor(n, new Color(0.55f, 0.3f, 0.1f));
            }
            _extraOccupiedSeats.Clear();

            // --- Audio off ---
            if (_ambientSource != null) _ambientSource.Stop();

            // --- Flags ---
            _hasTicket  = false;
            _hasPopcorn = false;
            AudioListener.volume = 1f;

            CinemaRunner.ShowHUD("  Theater Reset. Enjoy again!", 3.5f, Color.green);
            Debug.Log("[Cinema] Theater fully reset.");
        }
    }
}
