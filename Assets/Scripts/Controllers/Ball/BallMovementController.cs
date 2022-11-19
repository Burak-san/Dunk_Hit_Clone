using System;
using UnityEngine;

namespace Controllers.Ball
{
    public class BallMovementController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D ballRigidbody;
        [SerializeField] private float speed;
        [SerializeField] private float jumpForce;
        public int direction;
        
        private void Start()
        {
            ballRigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            Movement();
        }

        private void Movement()
        {
            ballRigidbody.velocity = new Vector2(speed * direction * Time.fixedDeltaTime, ballRigidbody.velocity.y);
        }

        public void Jump()
        {
            ballRigidbody.velocity = new Vector2(ballRigidbody.velocity.x, 0);
            ballRigidbody.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
        }
        
    }
}