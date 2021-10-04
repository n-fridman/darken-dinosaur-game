using UnityEngine;

namespace DarkenDinosaur.UI.Presenters.Gameplay
{
    public class OverlayPresenter : MonoBehaviour
    {
        [Header("Components")] 
        [SerializeField] private GameObject _overlayContainer;
        
        /// <summary>
        /// Show game overlay.
        /// </summary>
        public void ShowGameOverlay()
        {
            _overlayContainer.SetActive(true);
        }
        
        /// <summary>
        /// Hide game overlay.
        /// </summary>
        public void HideGameOverlay()
        {
            _overlayContainer.SetActive(false);
        }
    }
}