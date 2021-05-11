using UnityEngine;

namespace DarkenDinosaur.Sound
{
    [RequireComponent(typeof(AudioSource))]
    public class ScoreSoundController : MonoBehaviour
    {
        [Header("Components")] 
        [SerializeField] private AudioSource audioSource;

        [Header("Settings")] 
        [SerializeField] private AudioClip scoreEven100Sound;
        [SerializeField] private AudioClip scoreEven250Sound;
        [SerializeField] private AudioClip scoreEven500Sound;
        
        private void Awake()
        {
            if (this.audioSource == null) this.audioSource = GetComponent<AudioSource>();
        }
        
        private bool IsEvenNumber(int value, int number) => value % number == 0;
        
        /// <summary>
        /// Score changed event handler.
        /// </summary>
        /// <param name="score">Score count.</param>
        public void OnScoreChanged(int score)
        {
            if (IsEvenNumber(score, 500)) this.audioSource.PlayOneShot(this.scoreEven500Sound);
            else if(IsEvenNumber(score, 250)) this.audioSource.PlayOneShot(this.scoreEven250Sound);
            else if(IsEvenNumber(score, 100)) this.audioSource.PlayOneShot(this.scoreEven100Sound);
        }
    }
}