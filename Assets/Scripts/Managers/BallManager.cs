using UnityEngine;
using Controllers.Ball;
using Signals;

namespace Managers
{
    public class BallManager : MonoBehaviour
    {
        [SerializeField] private BallMovementController ballMovementController;

        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            InputSignals.Instance.onInputTaken += OnInputTaken;

            ScoreSignals.Instance.onGainScore += OnBasket;
        }

        private void UnSubscribeEvents()
        {
            InputSignals.Instance.onInputTaken -= OnInputTaken;
            ScoreSignals.Instance.onGainScore -= OnBasket;
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        #endregion

        private void OnInputTaken()
        {
            ballMovementController.Jump();
        }

        public void SetBallDirection()
        {
            ballMovementController.SetBallDirection();
        }

        public void SetSpeed()
        {
            ballMovementController.SetSpeed();
        }
        
        private void OnBasket()
        {
            ballMovementController.Basket();
        }
    }
}

