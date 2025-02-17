using UnityEngine;

namespace ActorController
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class Movement2D : MonoBehaviour {
        private Vector2 _velocity;
        public Rigidbody2D Rigidbody { get; private set; }

        void Start()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            Rigidbody.linearVelocityX = _velocity.x;
        }

        public void Move(float moveForce){
            _velocity.x = moveForce;
        }

        public void Jump(float jumpForce){
            Rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
}

