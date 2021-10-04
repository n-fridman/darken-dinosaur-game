using UnityEngine;

namespace DarkenDinosaur.UI.Presenters.Gameplay
{
    [AddComponentMenu("Darken Dinosaur/UI/Presenters/Gameplay/Restart Screen Presenter")]
    public class RestartScreenPresenter : MonoBehaviour
    {
        [Header("Components")] 
        [SerializeField] private GameObject _restartScreenContainer;
        [SerializeField] private GameObject _updateHighScoreRestartScreen;
        [SerializeField] private GameObject _defaultRestartScreen;

        [Header("Settings")] 
        [SerializeField] private bool _highScoreUpdated;

        /// <summary>
        /// High score changed event handler.
        /// </summary>
        public void OnHighScoreChanged() => _highScoreUpdated = true;
        
        /// <summary>
        /// Game lose event handler.
        /// </summary>
        public void OnDead()
        {
            _restartScreenContainer.SetActive(true);
            
            if (_highScoreUpdated) _updateHighScoreRestartScreen.SetActive(true);
            else _defaultRestartScreen.SetActive(true);
        }
    }
}