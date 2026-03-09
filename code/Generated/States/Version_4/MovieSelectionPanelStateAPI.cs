// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public static class MovieSelectionPanelStateAPI
    {
        public static bool Idle(GameObject obj) => MovieSelectionPanelStateStorage.IsIdle(obj);
        public static bool Action(GameObject obj) => MovieSelectionPanelStateStorage.IsAction(obj);
        public static bool Horror(GameObject obj) => MovieSelectionPanelStateStorage.IsHorror(obj);
        public static bool Scifi(GameObject obj) => MovieSelectionPanelStateStorage.IsScifi(obj);

        public static void SetIdle(GameObject obj) => MovieSelectionPanelStateStorage.SetIdle(obj);
        public static void SetAction(GameObject obj) => MovieSelectionPanelStateStorage.SetAction(obj);
        public static void SetHorror(GameObject obj) => MovieSelectionPanelStateStorage.SetHorror(obj);
        public static void SetScifi(GameObject obj) => MovieSelectionPanelStateStorage.SetScifi(obj);
    }
}
