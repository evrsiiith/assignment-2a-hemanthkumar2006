// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public class CycleLighting_LightingPanel : MonoBehaviour
    {
        void Update()
        {
            if ((UserAlgorithms.IsLightingPanelClicked()))
            {
                UserAlgorithms.CycleLighting(GameObject.Find("LightingPanel"));
            }
        }
    }
}
