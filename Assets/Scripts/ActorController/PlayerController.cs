using System.Collections;
using UnityEngine;

namespace ActorController 
{
    [RequireComponent(typeof(PlayerMovement2D), typeof(PlayerPolymorph))]
    public class PlayerController : MonoBehaviour, IActorController
    {
        public PlayerMovement2D MovementController { get; set; }
        public PlayerPolymorph PolymorphController { get; set; }
        
        private void Start() {
            MovementController = GetComponent<PlayerMovement2D>();
            PolymorphController = GetComponent<PlayerPolymorph>();
        }
    }
}