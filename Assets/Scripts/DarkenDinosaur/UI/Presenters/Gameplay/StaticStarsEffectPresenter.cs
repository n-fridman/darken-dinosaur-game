using UnityEngine;

namespace DarkenDinosaur.UI
{
    public class StaticStarsEffectPresenter : MonoBehaviour
    {
        [Header("Components")] 
        [SerializeField] private GameObject _particlesGameObject;
        [SerializeField] private Animator _particlesAnimator;

        private static readonly int GameStartTrigger = Animator.StringToHash("GameStart");
        
        private void OnValidate()
        {
            if (_particlesGameObject == null) _particlesGameObject = gameObject;
            if (_particlesAnimator == null) _particlesAnimator = GetComponent<Animator>();
        }

        /// <summary>
        /// Game start event handler.
        /// </summary>
        public void OnGameStar() => _particlesAnimator.SetTrigger(GameStartTrigger);
        
        /// <summary>
        /// Game start animation end event handler.
        /// </summary>
        public void OnAnimationEnd() => _particlesGameObject.SetActive(false);
    }
}