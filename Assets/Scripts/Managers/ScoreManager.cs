using Data.UnityObjects;
using Data.ValueObjects;
using Signals;
using UnityEngine;

namespace Managers
{
    public class ScoreManager : MonoBehaviour
    {
        public ScoreData Data;
        private bool _scoreIncreaseable = true;

        private void Start()
        {
            GetReferences();
        }

        private void GetReferences()
        {
            Data = GetScoreData;
            Data.Score = 0;
            UISignals.Instance.onSetScoreText?.Invoke(Data.Score);
            UISignals.Instance.onSetHighScoreText?.Invoke(Data.HighScore);
        }

        private ScoreData GetScoreData => Resources.Load<CD_Score>("Data/CD_Score").ScoreData;
        
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

            CoreGameSignals.Instance.onReset += OnReset;
        }

        private void UnSubscribedEvents()
        {
            ScoreSignals.Instance.onGainScore -= OnGainScore;
            ScoreSignals.Instance.onScoreIncreaseable -= OnScoreIncreaseable;
            ScoreSignals.Instance.onScoreGainBlocked -= OnScoreGainBlocked;
            
            CoreGameSignals.Instance.onReset -= OnReset;
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
                Data.Score += 1;
                UISignals.Instance.onSetScoreText?.Invoke(Data.Score);
                UISignals.Instance.onSetGainScoreText?.Invoke(Data.GainScore);
                UISignals.Instance.onSetTimeSliderValue?.Invoke();
            }

            if (Data.HighScore<Data.Score)
            {
                Data.HighScore = Data.Score;
                UISignals.Instance.onSetHighScoreText?.Invoke(Data.HighScore);
            }
        }
        
        private void OnScoreGainBlocked()
        {
            _scoreIncreaseable = false;
        }
        
        private void OnReset()
        {
            Data.Score = 0;
        }
    }
}