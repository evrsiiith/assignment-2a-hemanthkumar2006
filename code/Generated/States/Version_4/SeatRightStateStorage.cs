// GENERATED FILE — DO NOT EDIT
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Version_4
{
    public static class SeatRightStateStorage
    {
        private static Dictionary<GameObject, SeatRightStateEnum> stateTable = new();

        public static event Action<GameObject, SeatRightStateEnum> OnStateChanged;

        public static void Register(GameObject obj, SeatRightStateEnum initialState)
        {
            if (!stateTable.ContainsKey(obj))
                stateTable.Add(obj, initialState);
        }

        public static SeatRightStateEnum Get(GameObject obj) => stateTable[obj];

        public static bool IsEmpty(GameObject obj) => stateTable[obj] == SeatRightStateEnum.Empty;
        public static bool IsOccupied(GameObject obj) => stateTable[obj] == SeatRightStateEnum.Occupied;

        public static void SetEmpty(GameObject obj) => SetState(obj, SeatRightStateEnum.Empty);
        public static void SetOccupied(GameObject obj) => SetState(obj, SeatRightStateEnum.Occupied);

        private static void SetState(GameObject obj, SeatRightStateEnum newState)
        {
            if (stateTable[obj] != newState)
            {
                stateTable[obj] = newState;
                OnStateChanged?.Invoke(obj, newState);
            }
        }
    }
}
