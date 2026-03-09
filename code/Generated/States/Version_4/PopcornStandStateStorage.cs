// GENERATED FILE — DO NOT EDIT
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Version_4
{
    public static class PopcornStandStateStorage
    {
        private static Dictionary<GameObject, PopcornStandStateEnum> stateTable = new();

        public static event Action<GameObject, PopcornStandStateEnum> OnStateChanged;

        public static void Register(GameObject obj, PopcornStandStateEnum initialState)
        {
            if (!stateTable.ContainsKey(obj))
                stateTable.Add(obj, initialState);
        }

        public static PopcornStandStateEnum Get(GameObject obj) => stateTable[obj];

        public static bool IsIdle(GameObject obj) => stateTable[obj] == PopcornStandStateEnum.Idle;
        public static bool IsServing(GameObject obj) => stateTable[obj] == PopcornStandStateEnum.Serving;

        public static void SetIdle(GameObject obj) => SetState(obj, PopcornStandStateEnum.Idle);
        public static void SetServing(GameObject obj) => SetState(obj, PopcornStandStateEnum.Serving);

        private static void SetState(GameObject obj, PopcornStandStateEnum newState)
        {
            if (stateTable[obj] != newState)
            {
                stateTable[obj] = newState;
                OnStateChanged?.Invoke(obj, newState);
            }
        }
    }
}
