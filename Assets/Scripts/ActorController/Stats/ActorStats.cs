using System;
using UnityEngine;

namespace ActorController
{
    public class ActorStats <T, U> : ScriptableObject 
    where T: JumpStats where U: MoveStats
    {
        public T jumpStats;
        public U moveStats;
    }

    [Serializable]
    public class JumpStats {
        public float JumpPower = 20;
    }

    [Serializable]
    public class MoveStats {
        public float BaseSpeed = 9;
    }
}