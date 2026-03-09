// GENERATED FILE — DO NOT EDIT
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Version_4
{
    public static class RightWallStateStorage
    {
        private static Dictionary<GameObject, RightWallStateEnum> stateTable = new();

        public static event Action<GameObject, RightWallStateEnum> OnStateChanged;

        public static void Register(GameObject obj, RightWallStateEnum initialState)
        {
            if (!stateTable.ContainsKey(obj))
                stateTable.Add(obj, initialState);
        }

        public static RightWallStateEnum Get(GameObject obj) => stateTable[obj];

        public static bool IsReady(GameObject obj) => stateTable[obj] == RightWallStateEnum.Ready;

        public static void SetReady(GameObject obj) => SetState(obj, RightWallStateEnum.Ready);

        private static void SetState(GameObject obj, RightWallStateEnum newState)
        {
            if (stateTable[obj] != newState)
            {
                stateTable[obj] = newState;
                OnStateChanged?.Invoke(obj, newState);
            }
        }
    }
}
