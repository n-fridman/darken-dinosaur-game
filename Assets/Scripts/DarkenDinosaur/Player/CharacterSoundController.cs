using System.Collections.Generic;
using UnityEngine;

namespace DarkenDinosaur.Player
{
    [RequireComponent(typeof(AudioSource))]
    public class CharacterSoundController : MonoBehaviour
    {
        [Header("Components")] 
        [SerializeField] private AudioSource audioSource;

        [Header("Settings")] 
        [SerializeField] private List<AudioClip> jumpSounds;
        [SerializeField] private List<AudioClip> deadSounds;
        
        private void Awake()
        {
            if (this.audioSource == null) this.audioSource = GetComponent<AudioSource>();
        }
        
        /// <summary>
        /// Play random jump sound.
        /// </summary>
        public void PlayJumpSound()
        {
            int i = Random.Range(0, this.jumpSounds.Count);
            this.audioSource.PlayOneShot(this.jumpSounds[i]);
        }
        
        /// <summary>
        /// Play random dead sound.
        /// </summary>
        public void PlayDeadSound()
        {
            int i = Random.Range(0, this.deadSounds.Count);
            this.audioSource.PlayOneShot(this.deadSounds[i]);
        }
    }
}