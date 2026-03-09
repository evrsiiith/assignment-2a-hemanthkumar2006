// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public class StartMovie_CinemaScreen : MonoBehaviour
    {
        void Update()
        {
            if ((CinemaScreenStateStorage.Get(GameObject.Find("CinemaScreen")) == CinemaScreenStateEnum.Off && UserAlgorithms.IsAnySeatOccupied() && UserAlgorithms.IsMovieModeSelected()))
            {
                UserAlgorithms.PlayMovie(GameObject.Find("CinemaScreen"));
            }
        }
    }
}
