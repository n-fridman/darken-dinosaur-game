using UnityEngine;
using UnityEngine.UI;

namespace DarkenDinosaur.UI
{
    [RequireComponent(typeof(Text))]
    public class ScorePresenter : MonoBehaviour
    {
        [Header("Components")] 
        [SerializeField] private Text scoreText;

        private void Awake()
        {
            if (this.scoreText == null) this.scoreText = GetComponent<Text>();
        }
        
        /// <summary>
        /// Score changed event handler.
        /// </summary>
        /// <param name="score">Score count.</param>
        public void OnScoreChanged(int score) => this.scoreText.text = score.ToString("0000");
        
        /// <summary>
        /// Hide score counter.
        /// </summary>
        public void HideScore() => this.gameObject.SetActive(false);
        
        /// <summary>
        /// Show score counter.
        /// </summary>
        public void ShowScore() => this.gameObject.SetActive(true);
    }
}