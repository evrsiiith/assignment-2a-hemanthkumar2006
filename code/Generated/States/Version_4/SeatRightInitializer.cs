// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public class SeatRightInitializer : MonoBehaviour
    {
        public SeatRightStateEnum initialState = SeatRightStateEnum.Empty;

        void Awake()
        {
            SeatRightStateStorage.Register(gameObject, initialState);
        }
    }
}
