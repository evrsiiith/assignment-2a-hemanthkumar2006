// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public static class LightingPanelStateAPI
    {
        public static bool Bright(GameObject obj) => LightingPanelStateStorage.IsBright(obj);
        public static bool Dim(GameObject obj) => LightingPanelStateStorage.IsDim(obj);
        public static bool Dark(GameObject obj) => LightingPanelStateStorage.IsDark(obj);

        public static void SetBright(GameObject obj) => LightingPanelStateStorage.SetBright(obj);
        public static void SetDim(GameObject obj) => LightingPanelStateStorage.SetDim(obj);
        public static void SetDark(GameObject obj) => LightingPanelStateStorage.SetDark(obj);
    }
}
