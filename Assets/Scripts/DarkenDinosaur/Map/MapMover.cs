using System.Collections;
using UnityEngine;

namespace DarkenDinosaur.Map
{
    public class MapMover : MonoBehaviour
    {
        [Header("Settings")] 
        [Tooltip("Minimum moving speed.")]
        [SerializeField] private float minSpeed;
        
        [Tooltip("Maximum moving speed.")]
        [SerializeField] private float maxSpeed;
        
        [Tooltip("Current speed.")]
        [SerializeField] private float speed;
        
        [Tooltip("Boost moving speed per second.")]
        [SerializeField] private float boostSpeedPerSecond;

        [SerializeField] private float nonBoostSpeedTime;
        
        [SerializeField] private bool isPLay;

        private void Update()
        {
            if (this.isPLay)
            {
                Vector3 position = transform.position;
                position = Vector3.Lerp(position, position + Vector3.left, Time.deltaTime * this.speed);
                transform.position = position;
            }
        }

        private IEnumerator SpeedCounter()
        {
            yield return new WaitForSeconds(this.nonBoostSpeedTime);
            
            while (true)
            {
                yield return new WaitForSeconds(0.1f);
                this.speed += boostSpeedPerSecond / 10;

                this.speed = Mathf.Clamp(this.speed, this.minSpeed, this.maxSpeed);
            }
        }

        /// <summary>
        /// Game start event handler.
        /// </summary>
        public void OnGameStart()
        {
            StartCoroutine(SpeedCounter());
            this.isPLay = true;
        }

        /// <summary>
        /// Game pause event handler.
        /// </summary>
        public void OnPause() => this.isPLay = false;
        
        /// <summary>
        /// Game continue event handler.
        /// </summary>
        public void OnContinue() => this.isPLay = true;
    }
}