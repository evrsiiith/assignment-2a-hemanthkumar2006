// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public static class CinemaScreenStateAPI
    {
        public static bool Off(GameObject obj) => CinemaScreenStateStorage.IsOff(obj);
        public static bool Playing(GameObject obj) => CinemaScreenStateStorage.IsPlaying(obj);

        public static void SetOff(GameObject obj) => CinemaScreenStateStorage.SetOff(obj);
        public static void SetPlaying(GameObject obj) => CinemaScreenStateStorage.SetPlaying(obj);
    }
}
