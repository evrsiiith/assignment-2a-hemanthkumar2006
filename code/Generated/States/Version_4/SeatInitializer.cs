// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public class SeatInitializer : MonoBehaviour
    {
        public SeatStateEnum initialState = SeatStateEnum.Empty;

        void Awake()
        {
            SeatStateStorage.Register(gameObject, initialState);
        }
    }
}
