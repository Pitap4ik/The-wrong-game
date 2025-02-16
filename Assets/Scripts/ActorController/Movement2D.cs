using UnityEngine;

namespace ActorController
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class Movement2D : MonoBehaviour {
        [SerializeField] private float _moveMultupliyer = 1;
        [SerializeField] private float _jumpMultipliyer = 5;
        private Vector2 _velocity;
        public Rigidbody2D Rigidbody { get; private set; }
        public float MoveMultupliyer { get => _moveMultupliyer; set => _moveMultupliyer = value; }
        public float JumpMultipliyer { get => _jumpMultipliyer; set => _jumpMultipliyer = value; }

        void Start()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            Rigidbody.linearVelocityX = _velocity.x;
        }

        public void Move(float moveForce){
            _velocity.x = moveForce * MoveMultupliyer;
        }

        public void Jump(float jumpForce){
            Rigidbody.AddForce(new Vector2(0, jumpForce * JumpMultipliyer), ForceMode2D.Impulse);
        }
    }
}

