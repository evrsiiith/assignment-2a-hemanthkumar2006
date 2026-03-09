// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public class BackWallInitializer : MonoBehaviour
    {
        public BackWallStateEnum initialState = BackWallStateEnum.Ready;

        void Awake()
        {
            BackWallStateStorage.Register(gameObject, initialState);
        }
    }
}
