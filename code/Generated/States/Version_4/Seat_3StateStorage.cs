// GENERATED FILE — DO NOT EDIT
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Version_4
{
    public static class Seat_3StateStorage
    {
        private static Dictionary<GameObject, Seat_3StateEnum> stateTable = new();

        public static event Action<GameObject, Seat_3StateEnum> OnStateChanged;

        public static void Register(GameObject obj, Seat_3StateEnum initialState)
        {
            if (!stateTable.ContainsKey(obj))
                stateTable.Add(obj, initialState);
        }

        public static Seat_3StateEnum Get(GameObject obj) => stateTable[obj];

        public static bool IsEmpty(GameObject obj) => stateTable[obj] == Seat_3StateEnum.Empty;
        public static bool IsOccupied(GameObject obj) => stateTable[obj] == Seat_3StateEnum.Occupied;

        public static void SetEmpty(GameObject obj) => SetState(obj, Seat_3StateEnum.Empty);
        public static void SetOccupied(GameObject obj) => SetState(obj, Seat_3StateEnum.Occupied);

        private static void SetState(GameObject obj, Seat_3StateEnum newState)
        {
            if (stateTable[obj] != newState)
            {
                stateTable[obj] = newState;
                OnStateChanged?.Invoke(obj, newState);
            }
        }
    }
}
