// GENERATED FILE — DO NOT EDIT
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Version_4
{
    public static class CinemaScreenStateStorage
    {
        private static Dictionary<GameObject, CinemaScreenStateEnum> stateTable = new();

        public static event Action<GameObject, CinemaScreenStateEnum> OnStateChanged;

        public static void Register(GameObject obj, CinemaScreenStateEnum initialState)
        {
            if (!stateTable.ContainsKey(obj))
                stateTable.Add(obj, initialState);
        }

        public static CinemaScreenStateEnum Get(GameObject obj) => stateTable[obj];

        public static bool IsOff(GameObject obj) => stateTable[obj] == CinemaScreenStateEnum.Off;
        public static bool IsPlaying(GameObject obj) => stateTable[obj] == CinemaScreenStateEnum.Playing;

        public static void SetOff(GameObject obj) => SetState(obj, CinemaScreenStateEnum.Off);
        public static void SetPlaying(GameObject obj) => SetState(obj, CinemaScreenStateEnum.Playing);

        private static void SetState(GameObject obj, CinemaScreenStateEnum newState)
        {
            if (stateTable[obj] != newState)
            {
                stateTable[obj] = newState;
                OnStateChanged?.Invoke(obj, newState);
            }
        }
    }
}
