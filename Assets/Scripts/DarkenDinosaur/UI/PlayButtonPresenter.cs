using UnityEngine;

namespace DarkenDinosaur.UI
{
    public class PlayButtonPresenter : MonoBehaviour
    {
        [Header("Game objects")] 
        [SerializeField] private GameObject playButton;
        
        /// <summary>
        /// Game start event handler.
        /// </summary>
        public void OnGameStart() => this.playButton.SetActive(false);
    }
}
