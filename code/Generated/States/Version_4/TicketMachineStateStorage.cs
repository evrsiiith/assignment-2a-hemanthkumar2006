// GENERATED FILE — DO NOT EDIT
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Version_4
{
    public static class TicketMachineStateStorage
    {
        private static Dictionary<GameObject, TicketMachineStateEnum> stateTable = new();

        public static event Action<GameObject, TicketMachineStateEnum> OnStateChanged;

        public static void Register(GameObject obj, TicketMachineStateEnum initialState)
        {
            if (!stateTable.ContainsKey(obj))
                stateTable.Add(obj, initialState);
        }

        public static TicketMachineStateEnum Get(GameObject obj) => stateTable[obj];

        public static bool IsIdle(GameObject obj) => stateTable[obj] == TicketMachineStateEnum.Idle;
        public static bool IsDispensed(GameObject obj) => stateTable[obj] == TicketMachineStateEnum.Dispensed;

        public static void SetIdle(GameObject obj) => SetState(obj, TicketMachineStateEnum.Idle);
        public static void SetDispensed(GameObject obj) => SetState(obj, TicketMachineStateEnum.Dispensed);

        private static void SetState(GameObject obj, TicketMachineStateEnum newState)
        {
            if (stateTable[obj] != newState)
            {
                stateTable[obj] = newState;
                OnStateChanged?.Invoke(obj, newState);
            }
        }
    }
}
