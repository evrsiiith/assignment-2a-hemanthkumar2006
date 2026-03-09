// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public class TheaterDoorInitializer : MonoBehaviour
    {
        public TheaterDoorStateEnum initialState = TheaterDoorStateEnum.Locked;

        void Awake()
        {
            TheaterDoorStateStorage.Register(gameObject, initialState);
        }
    }
}
