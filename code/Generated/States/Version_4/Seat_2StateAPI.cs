// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public static class Seat_2StateAPI
    {
        public static bool Empty(GameObject obj) => Seat_2StateStorage.IsEmpty(obj);
        public static bool Occupied(GameObject obj) => Seat_2StateStorage.IsOccupied(obj);

        public static void SetEmpty(GameObject obj) => Seat_2StateStorage.SetEmpty(obj);
        public static void SetOccupied(GameObject obj) => Seat_2StateStorage.SetOccupied(obj);
    }
}
