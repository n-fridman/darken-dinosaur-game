using UnityEngine;
using UnityEngine.Events;

namespace DarkenDinosaur.Player
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(CapsuleCollider2D))]
    [RequireComponent(typeof(CharacterMovementController))]
    [RequireComponent(typeof(CharacterAnimationController))]
    [RequireComponent(typeof(CharacterSoundController))]
    public class Character : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private CharacterMovementController characterMovement;
        [SerializeField] private CharacterAnimationController characterAnimation;
        [SerializeField] private CharacterSoundController characterSound;

        [SerializeField] private UnityEvent jump;
        [SerializeField] private UnityEvent dead;
        [SerializeField] private UnityEvent crouchRunStart;
        [SerializeField] private UnityEvent crouchRunEnd;

        private void Awake()
        {
            if (this.characterMovement == null) this.characterMovement = GetComponent<CharacterMovementController>();
            if (this.characterAnimation == null) this.characterAnimation = GetComponent<CharacterAnimationController>();
            if (this.characterSound == null) this.characterSound = GetComponent<CharacterSoundController>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            switch (other.gameObject.tag)
            {
                case "Obstacle":
                    this.characterSound.PlayDeadSound();
                    this.dead?.Invoke();
                    Debug.Log("{<color=lime><b>Character Log</b></color>} => [Character] - (<color=yellow>OnCollisionEnter2D</color>) -> Character dead.");
                    break;
            }
        }

        /// <summary>
        /// Jump button down event handler.
        /// </summary>
        public void OnJumpButtonDown()
        {
            bool idGround = this.characterMovement.IsGround();
            if (idGround)
            {
                this.characterMovement.Jump();
                this.characterAnimation.SetJump();
                this.characterSound.PlayJumpSound();
                this.jump?.Invoke();
            }
        }
        
        /// <summary>
        /// Crouch run button down event handler.
        /// </summary>
        public void OnCrouchRunButtonDown()
        {
            bool isGround = this.characterMovement.IsGround();
            if (isGround)
            {
                this.characterAnimation.SetCrouchRun(true);
                this.crouchRunStart?.Invoke();
            }
        }
        
        /// <summary>
        /// Crouch run button up event handler.
        /// </summary>
        public void OnCrouchRunButtonUp()
        {
            bool isGround = this.characterMovement.IsGround();
            if (isGround)
            {
                this.characterAnimation.SetCrouchRun(false);
                this.crouchRunEnd?.Invoke();
            }
        }
        
        /// <summary>
        /// Game start event handler.
        /// </summary>
        public void OnGameStart()
        {
            this.characterAnimation.SetGameStart();
        }
    }
}
