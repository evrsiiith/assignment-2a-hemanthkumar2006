// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public static class TheaterDoorStateAPI
    {
        public static bool Locked(GameObject obj) => TheaterDoorStateStorage.IsLocked(obj);
        public static bool Unlocked(GameObject obj) => TheaterDoorStateStorage.IsUnlocked(obj);
        public static bool Open(GameObject obj) => TheaterDoorStateStorage.IsOpen(obj);

        public static void SetLocked(GameObject obj) => TheaterDoorStateStorage.SetLocked(obj);
        public static void SetUnlocked(GameObject obj) => TheaterDoorStateStorage.SetUnlocked(obj);
        public static void SetOpen(GameObject obj) => TheaterDoorStateStorage.SetOpen(obj);
    }
}
