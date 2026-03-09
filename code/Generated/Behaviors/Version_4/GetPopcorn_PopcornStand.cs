// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public class GetPopcorn_PopcornStand : MonoBehaviour
    {
        void Update()
        {
            if ((PopcornStandStateStorage.Get(GameObject.Find("PopcornStand")) == PopcornStandStateEnum.Idle && UserAlgorithms.IsStandClicked()))
            {
                UserAlgorithms.ServePopcorn();
            }
        }
    }
}
