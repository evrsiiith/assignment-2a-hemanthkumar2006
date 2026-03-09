// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public class HorrorLighting_LightingPanel : MonoBehaviour
    {
        void Update()
        {
            if ((CinemaScreenStateStorage.Get(GameObject.Find("CinemaScreen")) == CinemaScreenStateEnum.Playing && MovieSelectionPanelStateStorage.Get(GameObject.Find("MovieSelectionPanel")) == MovieSelectionPanelStateEnum.Horror))
            {
                UserAlgorithms.SetHorrorLighting(GameObject.Find("LightingPanel"));
            }
        }
    }
}
