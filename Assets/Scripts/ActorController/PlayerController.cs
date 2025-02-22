using System.Collections;
using UnityEngine;

namespace ActorController 
{
    [RequireComponent(typeof(PlayerMovement2D))]
    public class PlayerController : MonoBehaviour, IActorController
    {
        public PlayerMovement2D MovementController { get; set; }
        
        private void Start() {
            MovementController = GetComponent<PlayerMovement2D>();
        }
    }
}