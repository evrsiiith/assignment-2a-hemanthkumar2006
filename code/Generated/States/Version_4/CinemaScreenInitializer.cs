// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public class CinemaScreenInitializer : MonoBehaviour
    {
        public CinemaScreenStateEnum initialState = CinemaScreenStateEnum.Off;

        void Awake()
        {
            CinemaScreenStateStorage.Register(gameObject, initialState);
        }
    }
}
