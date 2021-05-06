using UnityEngine;

namespace DarkenDinosaur.Player
{
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimationController : MonoBehaviour
    {
        [Header("Components")] 
        [SerializeField] private Animator animator;
        [SerializeField] private CharacterMovementController characterMovement;
        
        private static readonly int GameStartTrigger = Animator.StringToHash("GameStart");
        private static readonly int JumpTrigger = Animator.StringToHash("Jump");
        private static readonly int IsGround = Animator.StringToHash("IsGround");
        private static readonly int IsCrouchRun = Animator.StringToHash("IsCrouchRun");
        
        private void Awake()
        {
            if (this.animator == null) this.animator = GetComponent<Animator>();
            if (this.characterMovement == null) this.characterMovement = GetComponent<CharacterMovementController>();
        }

        private void Update()
        {
            bool isGround = this.characterMovement.IsGround();
            SetIsGround(isGround);
        }

        /// <summary>
        /// Set Jump animation trigger.
        /// </summary>
        public void SetJump() => this.animator.SetTrigger(JumpTrigger);

        /// <summary>
        /// Set GameStart animation trigger.
        /// </summary>
        public void SetGameStart() => this.animator.SetTrigger(GameStartTrigger);

        /// <summary>
        /// Set is ground animation property.
        /// </summary>
        /// <param name="value">Value</param>
        public void SetIsGround(bool value) => this.animator.SetBool(IsGround, value);

        /// <summary>
        /// Set is crouch run animation property.
        /// </summary>
        /// <param name="value">Value</param>
        public void SetCrouchRun(bool value) => this.animator.SetBool(IsCrouchRun, value);
    }
}