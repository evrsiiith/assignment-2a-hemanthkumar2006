// GENERATED FILE — DO NOT EDIT
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Version_4
{
    public static class CeilingStateStorage
    {
        private static Dictionary<GameObject, CeilingStateEnum> stateTable = new();

        public static event Action<GameObject, CeilingStateEnum> OnStateChanged;

        public static void Register(GameObject obj, CeilingStateEnum initialState)
        {
            if (!stateTable.ContainsKey(obj))
                stateTable.Add(obj, initialState);
        }

        public static CeilingStateEnum Get(GameObject obj) => stateTable[obj];

        public static bool IsReady(GameObject obj) => stateTable[obj] == CeilingStateEnum.Ready;

        public static void SetReady(GameObject obj) => SetState(obj, CeilingStateEnum.Ready);

        private static void SetState(GameObject obj, CeilingStateEnum newState)
        {
            if (stateTable[obj] != newState)
            {
                stateTable[obj] = newState;
                OnStateChanged?.Invoke(obj, newState);
            }
        }
    }
}
