// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public class OpenDoor_TheaterDoor : MonoBehaviour
    {
        void Update()
        {
            if ((TheaterDoorStateStorage.Get(GameObject.Find("TheaterDoor")) == TheaterDoorStateEnum.Unlocked && UserAlgorithms.IsDoorClicked(GameObject.Find("TheaterDoor"))))
            {
                UserAlgorithms.OpenTheaterDoor(GameObject.Find("TheaterDoor"));
            }
        }
    }
}
