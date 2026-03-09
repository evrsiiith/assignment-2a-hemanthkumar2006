// GENERATED FILE — DO NOT EDIT
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Version_4
{
    public static class FrontWallStateStorage
    {
        private static Dictionary<GameObject, FrontWallStateEnum> stateTable = new();

        public static event Action<GameObject, FrontWallStateEnum> OnStateChanged;

        public static void Register(GameObject obj, FrontWallStateEnum initialState)
        {
            if (!stateTable.ContainsKey(obj))
                stateTable.Add(obj, initialState);
        }

        public static FrontWallStateEnum Get(GameObject obj) => stateTable[obj];

        public static bool IsReady(GameObject obj) => stateTable[obj] == FrontWallStateEnum.Ready;

        public static void SetReady(GameObject obj) => SetState(obj, FrontWallStateEnum.Ready);

        private static void SetState(GameObject obj, FrontWallStateEnum newState)
        {
            if (stateTable[obj] != newState)
            {
                stateTable[obj] = newState;
                OnStateChanged?.Invoke(obj, newState);
            }
        }
    }
}
