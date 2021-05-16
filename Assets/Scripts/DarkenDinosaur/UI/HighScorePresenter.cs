using DarkenDinosaur.Data;
using UnityEngine;
using UnityEngine.UI;

namespace DarkenDinosaur.UI
{
    [RequireComponent(typeof(Text))]
    public class HighScorePresenter : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Text highScoreText;

        [Header("Settings")] 
        [SerializeField] private string prefix;
        
        private void Awake()
        {
            if (this.highScoreText == null) this.highScoreText = GetComponent<Text>();
        }
        
        /// <summary>
        /// Data loaded event handler.
        /// </summary>
        /// <param name="data">Game data.</param>
        public void OnDataLoaded(GameData data) => this.highScoreText.text = $"{this.prefix} {data.highScoreCount}";
        
        /// <summary>
        /// On high score changed event handler.
        /// </summary>
        /// <param name="highScore">High score count.</param>
        public void OnHighScoreChanged(int highScore) => this.highScoreText.text = $"{this.prefix}  {highScore}";
    }
}