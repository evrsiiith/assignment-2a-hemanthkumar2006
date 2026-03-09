// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public class SitDown_Seat : MonoBehaviour
    {
        void Update()
        {
            if ((SeatStateStorage.Get(GameObject.Find("Seat")) == SeatStateEnum.Empty && UserAlgorithms.IsSeatClicked(GameObject.Find("Seat"))))
            {
                UserAlgorithms.SitOnSeat(GameObject.Find("Seat"));
            }
        }
    }
}
