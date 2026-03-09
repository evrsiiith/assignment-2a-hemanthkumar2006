// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public class UnlockDoor_TheaterDoor : MonoBehaviour
    {
        void Update()
        {
            if ((TheaterDoorStateStorage.Get(GameObject.Find("TheaterDoor")) == TheaterDoorStateEnum.Locked && UserAlgorithms.CheckHasTicket()))
            {
                UserAlgorithms.UnlockTheaterDoor(GameObject.Find("TheaterDoor"));
            }
        }
    }
}
