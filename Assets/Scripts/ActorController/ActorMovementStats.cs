using System;
using System.Collections.Generic;
using UnityEngine;

namespace ActorController
{
    public class ActorMovementStats <T, U> : ScriptableObject
    where T: JumpStats where U: MoveStats
    {
        public T jumpStats;
        public U moveStats;
    }

    public class ActorStats : ActorMovementStats<JumpStats, MoveStats> {}

    [Serializable]
    public class JumpStats{
        public float baseGravityScale = 20f;
        public float fallSpeed = 20f;
        public float jumpPower = 20;
        public LayerMask groundLayer;
        public Vector2 groundCheckBoxSize = new Vector2(0.5f, 0.1f);
        public float groundCheckCastDistance = 0.5f;
    }

    [Serializable]
    public class MoveStats {
        public float baseSpeed = 9;
    }
}