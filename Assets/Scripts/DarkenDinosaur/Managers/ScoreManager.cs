using System.Collections;
using DarkenDinosaur.Data;
using UnityEngine;
using UnityEngine.Events;

namespace DarkenDinosaur.Managers
{
    public class ScoreManager : MonoBehaviour
    {
        [Header("Settings")] 
        [SerializeField] private int addScorePerIteration;
        [SerializeField] private float iterationDelta;
        [SerializeField] private float minIterationDelta;
        [SerializeField] private float maxIterationDelta;
        [SerializeField] private float lessDeltaPerSecond;
        [SerializeField] private float nonLessDeltaTime;
        [Space] 
        [SerializeField] private int scoreCount;
        [SerializeField] private int highScoreCount;

        [SerializeField] private UnityEvent<int> scoreChanged;
        [SerializeField] private UnityEvent<int> highScoreChanged;
        
        private IEnumerator ScoreCounter()
        {
            while (true)
            {
                this.scoreCount += this.addScorePerIteration;
                this.scoreChanged?.Invoke(this.scoreCount);

                if (this.scoreCount > this.highScoreCount)
                {
                    this.highScoreCount = this.scoreCount;
                    this.highScoreChanged?.Invoke(this.highScoreCount);
                }

                yield return new WaitForSeconds(this.iterationDelta);
            }
        }

        private IEnumerator IterationDeltaCounter()
        {
            yield return new WaitForSeconds(this.nonLessDeltaTime);
            while (true)
            {
                this.iterationDelta -= this.lessDeltaPerSecond / 10;
                this.iterationDelta = Mathf.Clamp(this.iterationDelta, this.minIterationDelta, this.maxIterationDelta);

                yield return new WaitForSeconds(0.1f);
            }
        }
        
        /// <summary>
        /// Game start event handler.
        /// </summary>
        public void OnGameStart()
        {
            StartCoroutine(ScoreCounter());
            StartCoroutine(IterationDeltaCounter());
        }
        
        /// <summary>
        /// Player dead event handler,
        /// </summary>
        public void OnPlayerDead()
        {
            StopAllCoroutines();
        }
        
        /// <summary>
        /// Data loaded event handler.
        /// </summary>
        /// <param name="data">Game data</param>
        public void OnDataLoaded(GameData data)
        {
            this.highScoreCount = data.highScoreCount;
        }
    }
}
