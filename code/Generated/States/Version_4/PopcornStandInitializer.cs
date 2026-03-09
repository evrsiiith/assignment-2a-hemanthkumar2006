// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public class PopcornStandInitializer : MonoBehaviour
    {
        public PopcornStandStateEnum initialState = PopcornStandStateEnum.Idle;

        void Awake()
        {
            PopcornStandStateStorage.Register(gameObject, initialState);
        }
    }
}
