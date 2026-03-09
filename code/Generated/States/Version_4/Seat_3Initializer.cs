// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public class Seat_3Initializer : MonoBehaviour
    {
        public Seat_3StateEnum initialState = Seat_3StateEnum.Empty;

        void Awake()
        {
            Seat_3StateStorage.Register(gameObject, initialState);
        }
    }
}
