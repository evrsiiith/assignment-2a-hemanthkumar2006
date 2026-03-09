// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public class SeatLeftInitializer : MonoBehaviour
    {
        public SeatLeftStateEnum initialState = SeatLeftStateEnum.Empty;

        void Awake()
        {
            SeatLeftStateStorage.Register(gameObject, initialState);
        }
    }
}
