// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public static class SeatLeftStateAPI
    {
        public static bool Empty(GameObject obj) => SeatLeftStateStorage.IsEmpty(obj);
        public static bool Occupied(GameObject obj) => SeatLeftStateStorage.IsOccupied(obj);

        public static void SetEmpty(GameObject obj) => SeatLeftStateStorage.SetEmpty(obj);
        public static void SetOccupied(GameObject obj) => SeatLeftStateStorage.SetOccupied(obj);
    }
}
