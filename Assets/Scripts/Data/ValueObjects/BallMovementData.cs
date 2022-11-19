using System;

namespace Data.ValueObjects
{
    [Serializable]
    public class BallMovementData
    {
        public float speed;
        public float jumpForce;
        public int direction;
    }
}