using System;
using UnityEngine;

namespace ActorController
{
    [CreateAssetMenu(fileName = "PlayerMovementStats", menuName = "Player Stats", order = 1)]
    public class PlayerMovementStats : ActorMovementStats<PlayerJumpStats, PlayerMoveStats>
    {
        
    }

    [Serializable]
    public class PlayerJumpStats : JumpStats {
        public Vector2 coyoteCheckBoxSize = new Vector2(0.5f, 0.1f);
        public float coyoteCheckCastDistance = 1f;
        public float jumpBufferedTime = 0.15f;
        public float extraGravityScale = 2f;
    }

    [Serializable]
    public class PlayerMoveStats : MoveStats{
        
    }
}