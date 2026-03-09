// GENERATED FILE — DO NOT EDIT
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Version_4
{
    public static class BackWallStateStorage
    {
        private static Dictionary<GameObject, BackWallStateEnum> stateTable = new();

        public static event Action<GameObject, BackWallStateEnum> OnStateChanged;

        public static void Register(GameObject obj, BackWallStateEnum initialState)
        {
            if (!stateTable.ContainsKey(obj))
                stateTable.Add(obj, initialState);
        }

        public static BackWallStateEnum Get(GameObject obj) => stateTable[obj];

        public static bool IsReady(GameObject obj) => stateTable[obj] == BackWallStateEnum.Ready;

        public static void SetReady(GameObject obj) => SetState(obj, BackWallStateEnum.Ready);

        private static void SetState(GameObject obj, BackWallStateEnum newState)
        {
            if (stateTable[obj] != newState)
            {
                stateTable[obj] = newState;
                OnStateChanged?.Invoke(obj, newState);
            }
        }
    }
}
