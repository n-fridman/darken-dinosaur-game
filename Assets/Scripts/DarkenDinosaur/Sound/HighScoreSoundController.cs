using System.Collections.Generic;
using UnityEngine;

namespace DarkenDinosaur.Sound
{
    [RequireComponent(typeof(AudioSource))]
    public class HighScoreSoundController : MonoBehaviour
    {
        [Header("Components")] 
        [SerializeField] private AudioSource audioSource;

        [Header("Settings")] 
        [SerializeField] private List<AudioClip> highScoreChangedSounds;
        [SerializeField] private bool isSoundPayed;
        
        private void Awake()
        {
            if (this.audioSource == null) this.audioSource = GetComponent<AudioSource>();
        }
        
        /// <summary>
        /// High score changed event handler.
        /// </summary>
        /// <param name="highScore">High score count.</param>
        public void OnHighScoreChanged(int highScore)
        {
            if (this.isSoundPayed == false)
            {
                this.isSoundPayed = true;
                int i = Random.Range(0, this.highScoreChangedSounds.Count);
                this.audioSource.PlayOneShot(this.highScoreChangedSounds[i]);
            }
        }
    }
}