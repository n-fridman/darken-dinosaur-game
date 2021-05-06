using System;
using UnityEngine;

namespace DarkenDinosaur.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterMovementController : MonoBehaviour
    {
        [Header("Components")] 
        [SerializeField] private Rigidbody2D rb;

        [Header("Settings")] 
        [SerializeField] private float jumpForce;
        [SerializeField] private float detectGroundRayLenght;

        [Header("Development settings")] 
        [SerializeField] private bool showDetectGroundRay;
        
        private void Awake()
        {
            if (this.rb == null) this.rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (this.showDetectGroundRay)
            {
                Debug.DrawRay(transform.position, Vector3.down * this.detectGroundRayLenght, Color.red);
            }
        }

        /// <summary>
        /// Check character stay on ground.
        /// </summary>
        /// <returns>IsGround (bool)</returns>
        public bool IsGround()
        {
            int groundLayerMask = LayerMask.GetMask("Ground");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, this.detectGroundRayLenght, groundLayerMask);
            return hit.collider;
        }
        
        /// <summary>
        /// Jump character.
        /// </summary>
        public void Jump() => this.rb.AddForce(Vector2.up * this.jumpForce, ForceMode2D.Impulse);
    }
}