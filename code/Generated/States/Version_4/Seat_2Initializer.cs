// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public class Seat_2Initializer : MonoBehaviour
    {
        public Seat_2StateEnum initialState = Seat_2StateEnum.Empty;

        void Awake()
        {
            Seat_2StateStorage.Register(gameObject, initialState);
        }
    }
}
