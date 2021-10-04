using UnityEngine;

namespace DarkenDinosaur.UI
{
    public class DynamicStarsEffectPresenter : MonoBehaviour
    {
        [Header("Components")] 
        [SerializeField] private GameObject _dynamicStarsGameObject;
        [SerializeField] private ParticleSystem _dynamicStarsParticleSystem;

        private void OnValidate()
        {
            if (_dynamicStarsGameObject == null) _dynamicStarsGameObject = gameObject;
            if (_dynamicStarsParticleSystem == null) _dynamicStarsParticleSystem = gameObject.GetComponent<ParticleSystem>();
        }

        /// <summary>
        /// Game start event handler.
        /// </summary>
        public void OnGameStart()
        {
            _dynamicStarsGameObject.SetActive(true);
            _dynamicStarsParticleSystem.Play();
        }
    }
}