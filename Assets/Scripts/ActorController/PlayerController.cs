using System.Collections;
using UnityEngine;

namespace ActorController 
{
    [RequireComponent(typeof(Movement2D))]
    public class PlayerController : MonoBehaviour, IActorController<PlayerStats>
    {
        [SerializeField] private PlayerStats _stats;
        public Movement2D MovementController { get; set; }
        public PlayerStats Stats { get => _stats; set => _stats = value; }

        private void Start() {
            MovementController = GetComponent<Movement2D>();
        }

        private void Update() {
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.X))){
                MovementController.Jump(1);
            }

            MovementController.Move(Input.GetAxis("Horizontal"));
        }
    }
}