// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public class BuyTicket_TicketMachine : MonoBehaviour
    {
        void Update()
        {
            if ((TicketMachineStateStorage.Get(GameObject.Find("TicketMachine")) == TicketMachineStateEnum.Idle && UserAlgorithms.IsTicketMachineClicked()))
            {
                UserAlgorithms.DispenseTicket();
            }
        }
    }
}
