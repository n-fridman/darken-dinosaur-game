using UnityEngine;

namespace DarkenDinosaur.UI
{
    public class RestartTooltipsPresenter : MonoBehaviour
    {
        [Header("Game objects")] 
        [SerializeField] private GameObject restartTooltipsContainer;

        /// <summary>
        /// Player dead event handler.
        /// </summary>
        public void OnPlayerDead() => this.restartTooltipsContainer.SetActive(true);
    }
}
