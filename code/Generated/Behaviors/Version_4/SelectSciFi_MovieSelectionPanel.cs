// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public class SelectSciFi_MovieSelectionPanel : MonoBehaviour
    {
        void Update()
        {
            if ((UserAlgorithms.IsSciFiSelected()))
            {
                UserAlgorithms.SetSciFiMode(GameObject.Find("MovieSelectionPanel"));
            }
        }
    }
}
