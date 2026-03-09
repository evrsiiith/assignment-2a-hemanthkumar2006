// GENERATED FILE — DO NOT EDIT
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Version_4
{
    public static class MovieSelectionPanelStateStorage
    {
        private static Dictionary<GameObject, MovieSelectionPanelStateEnum> stateTable = new();

        public static event Action<GameObject, MovieSelectionPanelStateEnum> OnStateChanged;

        public static void Register(GameObject obj, MovieSelectionPanelStateEnum initialState)
        {
            if (!stateTable.ContainsKey(obj))
                stateTable.Add(obj, initialState);
        }

        public static MovieSelectionPanelStateEnum Get(GameObject obj) => stateTable[obj];

        public static bool IsIdle(GameObject obj) => stateTable[obj] == MovieSelectionPanelStateEnum.Idle;
        public static bool IsAction(GameObject obj) => stateTable[obj] == MovieSelectionPanelStateEnum.Action;
        public static bool IsHorror(GameObject obj) => stateTable[obj] == MovieSelectionPanelStateEnum.Horror;
        public static bool IsScifi(GameObject obj) => stateTable[obj] == MovieSelectionPanelStateEnum.Scifi;

        public static void SetIdle(GameObject obj) => SetState(obj, MovieSelectionPanelStateEnum.Idle);
        public static void SetAction(GameObject obj) => SetState(obj, MovieSelectionPanelStateEnum.Action);
        public static void SetHorror(GameObject obj) => SetState(obj, MovieSelectionPanelStateEnum.Horror);
        public static void SetScifi(GameObject obj) => SetState(obj, MovieSelectionPanelStateEnum.Scifi);

        private static void SetState(GameObject obj, MovieSelectionPanelStateEnum newState)
        {
            if (stateTable[obj] != newState)
            {
                stateTable[obj] = newState;
                OnStateChanged?.Invoke(obj, newState);
            }
        }
    }
}
