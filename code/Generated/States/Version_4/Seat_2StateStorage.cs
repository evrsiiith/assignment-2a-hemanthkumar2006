// GENERATED FILE — DO NOT EDIT
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Version_4
{
    public static class Seat_2StateStorage
    {
        private static Dictionary<GameObject, Seat_2StateEnum> stateTable = new();

        public static event Action<GameObject, Seat_2StateEnum> OnStateChanged;

        public static void Register(GameObject obj, Seat_2StateEnum initialState)
        {
            if (!stateTable.ContainsKey(obj))
                stateTable.Add(obj, initialState);
        }

        public static Seat_2StateEnum Get(GameObject obj) => stateTable[obj];

        public static bool IsEmpty(GameObject obj) => stateTable[obj] == Seat_2StateEnum.Empty;
        public static bool IsOccupied(GameObject obj) => stateTable[obj] == Seat_2StateEnum.Occupied;

        public static void SetEmpty(GameObject obj) => SetState(obj, Seat_2StateEnum.Empty);
        public static void SetOccupied(GameObject obj) => SetState(obj, Seat_2StateEnum.Occupied);

        private static void SetState(GameObject obj, Seat_2StateEnum newState)
        {
            if (stateTable[obj] != newState)
            {
                stateTable[obj] = newState;
                OnStateChanged?.Invoke(obj, newState);
            }
        }
    }
}
