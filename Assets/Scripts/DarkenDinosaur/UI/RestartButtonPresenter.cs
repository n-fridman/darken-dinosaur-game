using UnityEngine;

namespace DarkenDinosaur.UI
{
    public class RestartButtonPresenter : MonoBehaviour
    {
        [Header("Game objects")] 
        [SerializeField] private GameObject restartButton;
        
        /// <summary>
        /// Player dead event handler.
        /// </summary>
        public void OnPLayerDead() => this.restartButton.SetActive(true);
    }
}
