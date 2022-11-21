using UnityEngine;
using Controllers.Ball;
using Signals;

namespace Managers
{
    public class BallManager : MonoBehaviour
    {
        [SerializeField] private BallMovementController ballMovementController;
        [SerializeField] private BallParticleController ballParticleController;

        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            InputSignals.Instance.onInputTaken += OnInputTaken;

            ScoreSignals.Instance.onGainScore += OnBasket;
            ScoreSignals.Instance.onCombo += OnCombo;
            ScoreSignals.Instance.onExitCombo += OnExitCombo;
        }

        private void UnSubscribeEvents()
        {
            InputSignals.Instance.onInputTaken -= OnInputTaken;
            ScoreSignals.Instance.onGainScore -= OnBasket;
            ScoreSignals.Instance.onCombo -= OnCombo;
            ScoreSignals.Instance.onExitCombo -= OnExitCombo;
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
        
        private void OnCombo(int count)
        {
            ballParticleController.Combo(count);
        }
        
        private void OnExitCombo()
        {
            ballParticleController.ExitCombo();
        }
    }
}

