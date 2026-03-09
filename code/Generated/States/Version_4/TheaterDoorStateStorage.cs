// GENERATED FILE — DO NOT EDIT
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Version_4
{
    public static class TheaterDoorStateStorage
    {
        private static Dictionary<GameObject, TheaterDoorStateEnum> stateTable = new();

        public static event Action<GameObject, TheaterDoorStateEnum> OnStateChanged;

        public static void Register(GameObject obj, TheaterDoorStateEnum initialState)
        {
            if (!stateTable.ContainsKey(obj))
                stateTable.Add(obj, initialState);
        }

        public static TheaterDoorStateEnum Get(GameObject obj) => stateTable[obj];

        public static bool IsLocked(GameObject obj) => stateTable[obj] == TheaterDoorStateEnum.Locked;
        public static bool IsUnlocked(GameObject obj) => stateTable[obj] == TheaterDoorStateEnum.Unlocked;
        public static bool IsOpen(GameObject obj) => stateTable[obj] == TheaterDoorStateEnum.Open;

        public static void SetLocked(GameObject obj) => SetState(obj, TheaterDoorStateEnum.Locked);
        public static void SetUnlocked(GameObject obj) => SetState(obj, TheaterDoorStateEnum.Unlocked);
        public static void SetOpen(GameObject obj) => SetState(obj, TheaterDoorStateEnum.Open);

        private static void SetState(GameObject obj, TheaterDoorStateEnum newState)
        {
            if (stateTable[obj] != newState)
            {
                stateTable[obj] = newState;
                OnStateChanged?.Invoke(obj, newState);
            }
        }
    }
}
