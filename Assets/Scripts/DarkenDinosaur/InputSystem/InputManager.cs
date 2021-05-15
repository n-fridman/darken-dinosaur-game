using UnityEngine;
using UnityEngine.Events;

namespace DarkenDinosaur.InputSystem
{
    public class InputManager : MonoBehaviour
    {
        [Header("Settings")] 
        [SerializeField] private bool isGameStarted;
        [SerializeField] private bool isPlayerDead;
        [Space]        
        [SerializeField] private UnityEvent gameStart;
        [SerializeField] private UnityEvent restartLevel;
        [SerializeField] private UnityEvent jumpButtonDown;
        [SerializeField] private UnityEvent crouchRunButtonDown;
        [SerializeField] private UnityEvent crouchRunButtonUp;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                OnPlayButtonDown();
                OnJumpButtonDown();
                OnRestartLevelButtonDown();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow)) OnCrouchRunButtonDown();
            if (Input.GetKeyUp(KeyCode.DownArrow)) OnCrouchRunButtonUp();
        }

        /// <summary>
        /// Player dead event handler.
        /// </summary>
        public void OnPlayerDead() => this.isPlayerDead = true;

        /// <summary>
        /// Restart level button down event handler.
        /// </summary>
        public void OnRestartLevelButtonDown()
        {
            if (this.isPlayerDead)
            {
                Debug.Log("{<color=green><b>Input Log</b></color>} => [InputManager] - (<color=yellow>OnRestartLevelButtonDown</color>) -> Scene restarted.");
                this.restartLevel?.Invoke();
            }
        }
        
        /// <summary>
        /// Play button down event handler.
        /// </summary>
        public void OnPlayButtonDown()
        {
            if (this.isGameStarted == false)
            {
                this.isGameStarted = true;
                this.gameStart?.Invoke();
                Debug.Log("{<color=green><b>Input Log</b></color>} => [InputManager] - (<color=yellow>OnPlayButtonDown</color>) -> Game started.");
            }
        }
        
        /// <summary>
        /// Jump button down event handler.
        /// </summary>
        public void OnJumpButtonDown()
        {
            this.jumpButtonDown?.Invoke();
            Debug.Log("{<color=green><b>Input Log</b></color>} => [InputManager] - (<color=yellow>OnJumpButtonDown</color>) -> Jump button down.");
        }
        
        /// <summary>
        /// Crouch run button down event handler.
        /// </summary>
        public void OnCrouchRunButtonDown()
        {
            this.crouchRunButtonDown?.Invoke();
            Debug.Log("{<color=green><b>Input Log</b></color>} => [InputManager] - (<color=yellow>OnCrouchRunButtonDown</color>) -> Crouch run button down.");
        }
        
        /// <summary>
        /// Crouch run button up event handler.
        /// </summary>
        public void OnCrouchRunButtonUp()
        {
            this.crouchRunButtonUp?.Invoke();
            Debug.Log("{<color=green><b>Input Log</b></color>} => [InputManager] - (<color=yellow>OnCrouchRunButtonUp</color>) -> Crouch run button up.");
        }
    }
}
