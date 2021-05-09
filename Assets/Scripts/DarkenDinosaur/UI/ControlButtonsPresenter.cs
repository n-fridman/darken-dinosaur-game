using UnityEngine;

namespace DarkenDinosaur.UI
{
    public class ControlButtonsPresenter : MonoBehaviour
    {
        [Header("Game objects")] 
        [SerializeField] private GameObject controlButtonsContainer;
        
        /// <summary>
        /// Game start event handler.
        /// </summary>
        public void OnGameStart() => this.controlButtonsContainer.SetActive(true);
    }
}
