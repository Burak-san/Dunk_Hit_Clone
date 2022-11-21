using Data.UnityObjects;
using Data.ValueObjects;
using Enums;
using Signals;
using UnityEngine;

namespace Controllers.Ball
{
    public class BallMovementController : MonoBehaviour
    {
        public BallMovementData Data;
        [SerializeField] private Rigidbody2D ballRigidbody;
        [SerializeField] private BallState ballState;
        
        private void Awake()
        {
            GetReferences();
        }

        private void GetReferences()
        {
            Data = GetBallMovementData();
            Data.direction = 1;
            ballRigidbody = GetComponent<Rigidbody2D>();
            ballState = BallState.Right;
        }

        private BallMovementData GetBallMovementData() => Resources.Load<CD_Ball>("Data/CD_Ball").BallMovementData;

        private void FixedUpdate()
        {
            if (ballState == BallState.Right)
            {
                RightDirection();
            }

            if (ballState == BallState.Left)
            {
                LeftDirection();
            }
        }
        
        private void RightDirection()
        {
            Data.direction = (ballState == BallState.Right) ? 1 : -1;
            Movement();
        }

        private void LeftDirection()
        {
            Data.direction = (ballState == BallState.Left) ? -1 : 1;
            Movement();
        }

        private void Movement()
        {
            ballRigidbody.velocity = new Vector2(Data.speed * Data.direction * Time.fixedDeltaTime, ballRigidbody.velocity.y);
        }

        public void Jump()
        {
            ballRigidbody.velocity = new Vector2(ballRigidbody.velocity.x, 0);
            ballRigidbody.AddForce(Vector2.up * Data.jumpForce,ForceMode2D.Impulse);
        }

        public void SetBallDirection()
        {
            if (ballState == BallState.Right)
            {
                ballState = BallState.Left;
                LeftDirection();
            }
            else if (ballState == BallState.Left)
            {
                ballState = BallState.Right;
                RightDirection();
                
            }
        }
    }
}