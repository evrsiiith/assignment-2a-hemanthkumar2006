// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public class TicketMachineInitializer : MonoBehaviour
    {
        public TicketMachineStateEnum initialState = TicketMachineStateEnum.Idle;

        void Awake()
        {
            TicketMachineStateStorage.Register(gameObject, initialState);
        }
    }
}
