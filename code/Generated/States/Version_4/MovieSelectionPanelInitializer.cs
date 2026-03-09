// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public class MovieSelectionPanelInitializer : MonoBehaviour
    {
        public MovieSelectionPanelStateEnum initialState = MovieSelectionPanelStateEnum.Idle;

        void Awake()
        {
            MovieSelectionPanelStateStorage.Register(gameObject, initialState);
        }
    }
}
