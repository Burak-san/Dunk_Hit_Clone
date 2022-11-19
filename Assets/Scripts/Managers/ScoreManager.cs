using System;
using Signals;
using UnityEngine;

namespace Managers
{
    public class ScoreManager : MonoBehaviour
    {
        private bool _scoreIncreaseable = true;

        #region Event Subscriptions

        private void OnEnable()
        {
            SubscribedEvents();
        }

        private void SubscribedEvents()
        {
            ScoreSignals.Instance.onGainScore += OnGainScore;
            ScoreSignals.Instance.onScoreIncreaseable += OnScoreIncreaseable;
            ScoreSignals.Instance.onScoreGainBlocked += OnScoreGainBlocked;
        }

        private void UnSubscribedEvents()
        {
            ScoreSignals.Instance.onGainScore -= OnGainScore;
            ScoreSignals.Instance.onScoreIncreaseable -= OnScoreIncreaseable;
            ScoreSignals.Instance.onScoreGainBlocked -= OnScoreGainBlocked;
        }

        private void OnDisable()
        {
            UnSubscribedEvents();
        }

        #endregion

        private void OnScoreIncreaseable()
        {
            _scoreIncreaseable = true;
        }
        
        private void OnGainScore()
        {
            if (_scoreIncreaseable == true)
            {
                Debug.Log("ScoreKazandın!!!");
            }
        }
        
        private void OnScoreGainBlocked()
        {
            _scoreIncreaseable = false;
        }
    }
}