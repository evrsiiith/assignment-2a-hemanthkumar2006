// GENERATED FILE — DO NOT EDIT
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Version_4
{
    public static class SeatLeftStateStorage
    {
        private static Dictionary<GameObject, SeatLeftStateEnum> stateTable = new();

        public static event Action<GameObject, SeatLeftStateEnum> OnStateChanged;

        public static void Register(GameObject obj, SeatLeftStateEnum initialState)
        {
            if (!stateTable.ContainsKey(obj))
                stateTable.Add(obj, initialState);
        }

        public static SeatLeftStateEnum Get(GameObject obj) => stateTable[obj];

        public static bool IsEmpty(GameObject obj) => stateTable[obj] == SeatLeftStateEnum.Empty;
        public static bool IsOccupied(GameObject obj) => stateTable[obj] == SeatLeftStateEnum.Occupied;

        public static void SetEmpty(GameObject obj) => SetState(obj, SeatLeftStateEnum.Empty);
        public static void SetOccupied(GameObject obj) => SetState(obj, SeatLeftStateEnum.Occupied);

        private static void SetState(GameObject obj, SeatLeftStateEnum newState)
        {
            if (stateTable[obj] != newState)
            {
                stateTable[obj] = newState;
                OnStateChanged?.Invoke(obj, newState);
            }
        }
    }
}
