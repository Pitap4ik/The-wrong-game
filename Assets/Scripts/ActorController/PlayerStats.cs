using System;
using UnityEngine;

namespace ActorController
{
    [CreateAssetMenu(fileName = "PlayerStats", menuName = "Player Stats", order = 1)]
    public class PlayerStats : ActorStats<PlayerJumpStats, PlayerMoveStats> 
    {
        
    }

    [Serializable]
    public class PlayerJumpStats : JumpStats {
        public float BufferedJumpTime = 0.15f;
        public float CoyoteTime = 0.15f;
    }

    [Serializable]
    public class PlayerMoveStats : MoveStats{
        public float Acceleration = 50;
    }
}