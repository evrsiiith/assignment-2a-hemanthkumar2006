// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public class FrontWallInitializer : MonoBehaviour
    {
        public FrontWallStateEnum initialState = FrontWallStateEnum.Ready;

        void Awake()
        {
            FrontWallStateStorage.Register(gameObject, initialState);
        }
    }
}
