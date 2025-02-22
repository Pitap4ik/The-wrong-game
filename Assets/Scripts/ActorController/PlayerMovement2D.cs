using System;
using System.Collections;
using UnityEngine;

namespace ActorController
{
    public enum JumpInput{
        None,
        Pressed,
        Released
    }
    
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class PlayerMovement2D : MonoBehaviour {
        private Vector2 _velocity;
        private bool _isJumping = false;
        private bool _endedJumpEarly = false;
        [SerializeField] private PlayerMovementStats _stats;
        public PlayerMovementStats Stats { get => _stats; private set => _stats = value; }
        public Vector2 Velocity { get => _velocity; private set => _velocity = value; }
        public Rigidbody2D Rigidbody { get; private set; }
        public bool IsJumping { get => _isJumping; private set => _isJumping = value; }

        void Start()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
            Rigidbody.gravityScale = 0;
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
            if ((GetJumpInput(JumpInput.Pressed)) && !IsJumping && (IsGrounded() || CanDoCayote())){
                Jump(Stats.jumpStats.maxJumpPower);
                IsJumping = true;
                _endedJumpEarly = false;
                StartCoroutine(JumpRoutine());
            }

            if (GetJumpInput(JumpInput.Released)){
                Debug.Log("R");
                if (IsJumping){
                    _endedJumpEarly = true;
                    _isJumping = false;
                }
            }
        }

        IEnumerator JumpRoutine()
        {
            yield return new WaitForSeconds(Stats.jumpStats.jumpBufferedTime);
            IsJumping = false;
        }
        
        void Fall()
        {
            if (!IsGrounded()){     
                float fallSpeed = _endedJumpEarly && _velocity.y > 0? Stats.jumpStats.fallSpeed * Stats.jumpStats.extraGravityScale : Stats.jumpStats.fallSpeed;
                _velocity.y -= fallSpeed * Time.deltaTime;
            }
            else if (IsGrounded() && _velocity.y < 0) {
                _velocity.y = 0f;
                IsJumping = false;
            }
        }

        public void Move(float moveForce){
            _velocity.x = moveForce * Stats.moveStats.baseSpeed;
        }

        public void Jump(float jumpForce){
            _velocity.y = jumpForce;
        }

        public bool GetJumpInput(JumpInput jumpInput){
            if (jumpInput == JumpInput.Pressed){
                return Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.X);
            } 
            else if (jumpInput == JumpInput.Released){
                return Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.X);
            }
            else {
                return false;
            }
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

