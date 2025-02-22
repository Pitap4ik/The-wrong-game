using System;
using UnityEngine;

namespace ActorController
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class PlayerMovement2D : MonoBehaviour {
        private Vector2 _velocity;
        [SerializeField] private PlayerMovementStats _stats;
        public PlayerMovementStats Stats { get => _stats; private set => _stats = value; }
        public Vector2 Velocity { get => _velocity; private set => _velocity = value; }
        public Rigidbody2D Rigidbody { get; private set; }

        void Start()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
            Rigidbody.gravityScale = Stats.jumpStats.baseGravityScale;
        }
        
        void FixedUpdate()
        {
            Fall();
            Rigidbody.linearVelocity = _velocity;
        }

        void Update()
        {
            GatherInput();
            Move(Input.GetAxis("Horizontal"));
        }

        void GatherInput()
        {
            if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.X)) && (IsGrounded() || CanDoCayote())){
                Jump(Stats.jumpStats.jumpPower);
            }
        }
        
        void Fall()
        {
            if (!IsGrounded()){
                float fallSpeed = Stats.jumpStats.fallSpeed;
                _velocity.y -= fallSpeed * Time.deltaTime;
            }
            else if (IsGrounded() && _velocity.y < 0) {
                _velocity.y = 0;
            }
        }

        public void Move(float moveForce){
            _velocity.x = moveForce * Stats.moveStats.baseSpeed;
        }

        public void Jump(float jumpForce){
            _velocity.y = jumpForce;
        }

        private bool IsGrounded()
        {
            if (Physics2D.BoxCast(transform.position, Stats.jumpStats.groundCheckBoxSize, 0, Vector2.down, Stats.jumpStats.groundCheckCastDistance, Stats.jumpStats.groundLayer))
            {
                return true;
            }
            else {
                return false;
            }
        }

        private bool CanDoCayote(){
            if (Physics2D.BoxCast(transform.position, Stats.jumpStats.coyoteCheckBoxSize, 0, Vector2.down, Stats.jumpStats.coyoteCheckCastDistance, Stats.jumpStats.groundLayer))
            {
                return true;
            }
            else {
                return false;
            }
        }

        private void OnDrawGizmos() {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position + (Vector3.down * Stats.jumpStats.groundCheckCastDistance), new Vector3(Stats.jumpStats.groundCheckBoxSize.x, Stats.jumpStats.groundCheckBoxSize.y, 1));
            
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(transform.position + (Vector3.down * Stats.jumpStats.coyoteCheckCastDistance), new Vector3(Stats.jumpStats.coyoteCheckBoxSize.x, Stats.jumpStats.coyoteCheckBoxSize.y, 1));
        }
    }
}

