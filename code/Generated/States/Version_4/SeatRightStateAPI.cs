// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public static class SeatRightStateAPI
    {
        public static bool Empty(GameObject obj) => SeatRightStateStorage.IsEmpty(obj);
        public static bool Occupied(GameObject obj) => SeatRightStateStorage.IsOccupied(obj);

        public static void SetEmpty(GameObject obj) => SeatRightStateStorage.SetEmpty(obj);
        public static void SetOccupied(GameObject obj) => SeatRightStateStorage.SetOccupied(obj);
    }
}
