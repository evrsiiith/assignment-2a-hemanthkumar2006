// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public static class Seat_3StateAPI
    {
        public static bool Empty(GameObject obj) => Seat_3StateStorage.IsEmpty(obj);
        public static bool Occupied(GameObject obj) => Seat_3StateStorage.IsOccupied(obj);

        public static void SetEmpty(GameObject obj) => Seat_3StateStorage.SetEmpty(obj);
        public static void SetOccupied(GameObject obj) => Seat_3StateStorage.SetOccupied(obj);
    }
}
