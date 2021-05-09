using UnityEngine;

namespace DarkenDinosaur.UI
{
    public class TooltipsPresenter : MonoBehaviour
    {
        [Header("Game objects")] 
        [SerializeField] private GameObject tooltipsContainer;

        /// <summary>
        /// Game start event handler.
        /// </summary>
        public void OnGameStart() => this.tooltipsContainer.SetActive(false);
    }
}