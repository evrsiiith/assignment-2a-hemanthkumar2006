// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public class CeilingInitializer : MonoBehaviour
    {
        public CeilingStateEnum initialState = CeilingStateEnum.Ready;

        void Awake()
        {
            CeilingStateStorage.Register(gameObject, initialState);
        }
    }
}
