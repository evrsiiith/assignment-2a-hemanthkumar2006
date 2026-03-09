// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public class LeftWallInitializer : MonoBehaviour
    {
        public LeftWallStateEnum initialState = LeftWallStateEnum.Ready;

        void Awake()
        {
            LeftWallStateStorage.Register(gameObject, initialState);
        }
    }
}
