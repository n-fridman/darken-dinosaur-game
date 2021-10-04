using DarkenDinosaur.Data;
using UnityEngine;
using UnityEngine.UI;

namespace DarkenDinosaur.UI.Presenters.Gameplay
{
    [AddComponentMenu("Darken Dinosaur/UI/Presenters/Gameplay/High Score Presenter")]
    [RequireComponent(typeof(Text))]
    public class HighScorePresenter : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Text _highScoreText;

        [Header("Settings")] 
        [SerializeField] private string _prefix;
        
        private void Awake()
        {
            if (_highScoreText == null) _highScoreText = GetComponent<Text>();
        }
        
        /// <summary>
        /// Data loaded event handler.
        /// </summary>
        /// <param name="data">Game data.</param>
        public void OnDataLoaded(GameData data) => _highScoreText.text = $"{_prefix}{data.highScoreCount:0000}";
        
        /// <summary>
        /// On high score changed event handler.
        /// </summary>
        /// <param name="highScore">High score count.</param>
        public void OnHighScoreChanged(int highScore) => _highScoreText.text = $"{_prefix}" + highScore.ToString("0000");
        
        /// <summary>
        /// Hide high score counter.
        /// </summary>
        public void HideHighScore() => gameObject.SetActive(false);
        
        /// <summary>
        /// Show high score counter.
        /// </summary>
        public void ShopHighScore() => gameObject.SetActive(true);
    }
}