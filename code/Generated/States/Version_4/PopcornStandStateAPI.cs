// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public static class PopcornStandStateAPI
    {
        public static bool Idle(GameObject obj) => PopcornStandStateStorage.IsIdle(obj);
        public static bool Serving(GameObject obj) => PopcornStandStateStorage.IsServing(obj);

        public static void SetIdle(GameObject obj) => PopcornStandStateStorage.SetIdle(obj);
        public static void SetServing(GameObject obj) => PopcornStandStateStorage.SetServing(obj);
    }
}
