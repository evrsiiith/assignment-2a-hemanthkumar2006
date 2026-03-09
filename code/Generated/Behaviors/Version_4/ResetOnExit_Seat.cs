// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public class ResetOnExit_Seat : MonoBehaviour
    {
        void Update()
        {
            if ((SeatStateStorage.Get(GameObject.Find("Seat")) == SeatStateEnum.Occupied && UserAlgorithms.IsSeatVacated(GameObject.Find("Seat"))))
            {
                UserAlgorithms.ResetTheater();
            }
        }
    }
}
