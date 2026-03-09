// GENERATED FILE — DO NOT EDIT
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Version_4
{
    public static class LeftWallStateStorage
    {
        private static Dictionary<GameObject, LeftWallStateEnum> stateTable = new();

        public static event Action<GameObject, LeftWallStateEnum> OnStateChanged;

        public static void Register(GameObject obj, LeftWallStateEnum initialState)
        {
            if (!stateTable.ContainsKey(obj))
                stateTable.Add(obj, initialState);
        }

        public static LeftWallStateEnum Get(GameObject obj) => stateTable[obj];

        public static bool IsReady(GameObject obj) => stateTable[obj] == LeftWallStateEnum.Ready;

        public static void SetReady(GameObject obj) => SetState(obj, LeftWallStateEnum.Ready);

        private static void SetState(GameObject obj, LeftWallStateEnum newState)
        {
            if (stateTable[obj] != newState)
            {
                stateTable[obj] = newState;
                OnStateChanged?.Invoke(obj, newState);
            }
        }
    }
}
