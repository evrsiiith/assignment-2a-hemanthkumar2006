// GENERATED FILE — DO NOT EDIT
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Version_4
{
    public static class LightingPanelStateStorage
    {
        private static Dictionary<GameObject, LightingPanelStateEnum> stateTable = new();

        public static event Action<GameObject, LightingPanelStateEnum> OnStateChanged;

        public static void Register(GameObject obj, LightingPanelStateEnum initialState)
        {
            if (!stateTable.ContainsKey(obj))
                stateTable.Add(obj, initialState);
        }

        public static LightingPanelStateEnum Get(GameObject obj) => stateTable[obj];

        public static bool IsBright(GameObject obj) => stateTable[obj] == LightingPanelStateEnum.Bright;
        public static bool IsDim(GameObject obj) => stateTable[obj] == LightingPanelStateEnum.Dim;
        public static bool IsDark(GameObject obj) => stateTable[obj] == LightingPanelStateEnum.Dark;

        public static void SetBright(GameObject obj) => SetState(obj, LightingPanelStateEnum.Bright);
        public static void SetDim(GameObject obj) => SetState(obj, LightingPanelStateEnum.Dim);
        public static void SetDark(GameObject obj) => SetState(obj, LightingPanelStateEnum.Dark);

        private static void SetState(GameObject obj, LightingPanelStateEnum newState)
        {
            if (stateTable[obj] != newState)
            {
                stateTable[obj] = newState;
                OnStateChanged?.Invoke(obj, newState);
            }
        }
    }
}
