// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public class LightingPanelInitializer : MonoBehaviour
    {
        public LightingPanelStateEnum initialState = LightingPanelStateEnum.Bright;

        void Awake()
        {
            LightingPanelStateStorage.Register(gameObject, initialState);
        }
    }
}
