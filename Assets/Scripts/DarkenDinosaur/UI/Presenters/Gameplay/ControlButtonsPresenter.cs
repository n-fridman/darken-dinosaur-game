using UnityEngine;

namespace DarkenDinosaur.UI.Presenters.Gameplay
{
    public class ControlButtonsPresenter : MonoBehaviour
    {
        [Header("Components")] 
        [SerializeField] private GameObject _controlButtonsContainer;

        /// <summary>
        /// Show control buttons.
        /// </summary>
        public void ShowControlButtons()
        {
            _controlButtonsContainer.SetActive(true);
        }

        /// <summary>
        /// Hide control buttons.
        /// </summary>
        public void HideControlButtons()
        {
            _controlButtonsContainer.SetActive(false);
        }
    }
}