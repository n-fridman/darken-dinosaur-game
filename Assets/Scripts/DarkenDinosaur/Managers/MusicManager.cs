using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DarkenDinosaur.Managers
{
    [RequireComponent(typeof(AudioSource))]
    public class MusicManager : MonoBehaviour
    {
        [Header("Components")] 
        [SerializeField] private AudioSource audioSource;

        [Header("Settings")] 
        [SerializeField] private List<AudioClip> backgroundMusicClips;
        
        private void Awake()
        {
            if (this.audioSource == null) this.audioSource = GetComponent<AudioSource>();

            MusicManager[] musicManagersOnScene = FindObjectsOfType<MusicManager>();
            if (musicManagersOnScene.Length > 1)
            {
                Debug.Log("{<color=purple><b>Music Log</b></color>} => [MusicManager] - (<color=yellow>Awake</color>) -> Delete duplicate music manager.");
                Destroy(this.gameObject); 
            }
            else
            {
                Debug.Log("{<color=purple><b>Music Log</b></color>} => [MusicManager] - (<color=yellow>Awake</color>) -> Music manager move to dont destroy on load.");
                DontDestroyOnLoad(this.gameObject);
            }
        }

        private void Update()
        {
            if (this.audioSource.isPlaying == false)
            {
                AudioClip clip = GetRandomTrack();
                this.audioSource.PlayOneShot(clip);
            }
        }

        /// <summary>
        /// Return random track from tracks.
        /// </summary>
        /// <returns>Audio Track (AudioClip)</returns>
        private AudioClip GetRandomTrack()
        {
            int i = Random.Range(0, this.backgroundMusicClips.Count);
            return this.backgroundMusicClips[i];
        }
    }
}
