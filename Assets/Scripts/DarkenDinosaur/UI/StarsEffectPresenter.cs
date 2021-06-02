using UnityEngine;

namespace DarkenDinosaur.UI
{
    public class StarsEffectPresenter : MonoBehaviour
    {
        [Header("Components")] 
        [SerializeField] private GameObject staticParticles;
        [SerializeField] private GameObject dynamicParticles;
        [SerializeField] private Animator staticParticlesAnimator;

        private static readonly int GameStart = Animator.StringToHash("GameStart");
        
        /// <summary>
        /// Game start event handler.
        /// </summary>
        public void OnGameStart()
        {
            this.staticParticlesAnimator.SetTrigger(GameStart);
            this.dynamicParticles.SetActive(true);
        }
    }
}