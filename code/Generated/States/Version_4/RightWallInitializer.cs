// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public class RightWallInitializer : MonoBehaviour
    {
        public RightWallStateEnum initialState = RightWallStateEnum.Ready;

        void Awake()
        {
            RightWallStateStorage.Register(gameObject, initialState);
        }
    }
}
