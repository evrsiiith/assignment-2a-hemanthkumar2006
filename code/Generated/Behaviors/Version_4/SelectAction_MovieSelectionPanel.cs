// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public class SelectAction_MovieSelectionPanel : MonoBehaviour
    {
        void Update()
        {
            if ((UserAlgorithms.IsActionSelected()))
            {
                UserAlgorithms.SetActionMode(GameObject.Find("MovieSelectionPanel"));
            }
        }
    }
}
