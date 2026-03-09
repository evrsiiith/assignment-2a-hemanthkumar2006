// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public class SelectHorror_MovieSelectionPanel : MonoBehaviour
    {
        void Update()
        {
            if ((UserAlgorithms.IsHorrorSelected()))
            {
                UserAlgorithms.SetHorrorMode(GameObject.Find("MovieSelectionPanel"));
            }
        }
    }
}
