using Data.UnityObjects;
using Data.ValueObjects;
using UnityEngine;

namespace Controllers.Ball
{
    public class BallMovementController : MonoBehaviour
    {
        public BallMovementData Data;
        [SerializeField] private Rigidbody2D ballRigidbody;
        
        
        private void Awake()
        {
            Data = GetBallMovementData();
            ballRigidbody = GetComponent<Rigidbody2D>();
        }

        private BallMovementData GetBallMovementData() => Resources.Load<CD_Ball>("Data/CD_Ball").BallMovementData;

        private void FixedUpdate()
        {
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
            Data.direction *= -1;
        }
        
    }
}