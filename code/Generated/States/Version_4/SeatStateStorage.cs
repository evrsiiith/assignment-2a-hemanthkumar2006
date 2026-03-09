// GENERATED FILE — DO NOT EDIT
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Version_4
{
    public static class SeatStateStorage
    {
        private static Dictionary<GameObject, SeatStateEnum> stateTable = new();

        public static event Action<GameObject, SeatStateEnum> OnStateChanged;

        public static void Register(GameObject obj, SeatStateEnum initialState)
        {
            if (!stateTable.ContainsKey(obj))
                stateTable.Add(obj, initialState);
        }

        public static SeatStateEnum Get(GameObject obj) => stateTable[obj];

        public static bool IsEmpty(GameObject obj) => stateTable[obj] == SeatStateEnum.Empty;
        public static bool IsOccupied(GameObject obj) => stateTable[obj] == SeatStateEnum.Occupied;

        public static void SetEmpty(GameObject obj) => SetState(obj, SeatStateEnum.Empty);
        public static void SetOccupied(GameObject obj) => SetState(obj, SeatStateEnum.Occupied);

        private static void SetState(GameObject obj, SeatStateEnum newState)
        {
            if (stateTable[obj] != newState)
            {
                stateTable[obj] = newState;
                OnStateChanged?.Invoke(obj, newState);
            }
        }
    }
}
