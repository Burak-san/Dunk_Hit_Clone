using System;
using Signals;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace Controllers.Ball
{
    public class BallPhysicsController : MonoBehaviour
    {
        private BallMovementController _ballMovementController;

        private void Awake()
        {
            _ballMovementController = GetComponent<BallMovementController>();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("LeftBorder"))
            {
                if (_ballMovementController.direction == -1)
                {
                    SetPosition(other);
                }
            }
            if (other.CompareTag("RightBorder"))
            {
                if (_ballMovementController.direction == 1)
                {
                    SetPosition(other);
                }
            }
            
            if (other.CompareTag("TopSideHook"))
            {
                ScoreSignals.Instance.onScoreIncreaseable?.Invoke();
                Debug.Log("TopSideHook");
            }

            if (other.CompareTag("InSideHook"))
            {
                ScoreSignals.Instance.onGainScore?.Invoke();
                Debug.Log("InSideHook");
            }
            
            if (other.CompareTag("BottomSideHook"))
            {
                ScoreSignals.Instance.onScoreGainBlocked?.Invoke();
                Debug.Log("BottomSideHook");
            }
        }

        public void SetPosition(Collider2D other)
        {
            _ballMovementController.transform.position = new Vector3(-other.transform.position.x, _ballMovementController.transform.position.y);
        }
    }
}