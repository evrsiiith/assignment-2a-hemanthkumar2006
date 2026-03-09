// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public class AutoDimLights_LightingPanel : MonoBehaviour
    {
        void Update()
        {
            if ((LightingPanelStateStorage.Get(GameObject.Find("LightingPanel")) == LightingPanelStateEnum.Bright && CinemaScreenStateStorage.Get(GameObject.Find("CinemaScreen")) == CinemaScreenStateEnum.Playing && UserAlgorithms.IsDimModeNeeded()))
            {
                UserAlgorithms.DimLightsForMovie(GameObject.Find("LightingPanel"));
            }
        }
    }
}
