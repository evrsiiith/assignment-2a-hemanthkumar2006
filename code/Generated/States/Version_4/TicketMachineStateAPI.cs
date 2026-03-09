// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public static class TicketMachineStateAPI
    {
        public static bool Idle(GameObject obj) => TicketMachineStateStorage.IsIdle(obj);
        public static bool Dispensed(GameObject obj) => TicketMachineStateStorage.IsDispensed(obj);

        public static void SetIdle(GameObject obj) => TicketMachineStateStorage.SetIdle(obj);
        public static void SetDispensed(GameObject obj) => TicketMachineStateStorage.SetDispensed(obj);
    }
}
