// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public static class SeatStateAPI
    {
        public static bool Empty(GameObject obj) => SeatStateStorage.IsEmpty(obj);
        public static bool Occupied(GameObject obj) => SeatStateStorage.IsOccupied(obj);

        public static void SetEmpty(GameObject obj) => SeatStateStorage.SetEmpty(obj);
        public static void SetOccupied(GameObject obj) => SeatStateStorage.SetOccupied(obj);
    }
}
