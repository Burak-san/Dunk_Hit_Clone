using Data.UnityObjects;
using Data.ValueObjects;
using Signals;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

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
            Data.Combo = 0;
            UISignals.Instance.onSetScoreText?.Invoke(Data.Score);
            UISignals.Instance.onSetHighScoreText?.Invoke(Data.HighScore);
            UISignals.Instance.onSetMaxComboScore?.Invoke(Data.MaxComboScore);
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
            ScoreSignals.Instance.onComboValueDecrease += OnComboDecrease;

            CoreGameSignals.Instance.onReset += OnReset;
        }

        private void UnSubscribedEvents()
        {
            ScoreSignals.Instance.onGainScore -= OnGainScore;
            ScoreSignals.Instance.onScoreIncreaseable -= OnScoreIncreaseable;
            ScoreSignals.Instance.onScoreGainBlocked -= OnScoreGainBlocked;
            ScoreSignals.Instance.onComboValueDecrease -= OnComboDecrease;
            
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
                Data.Score += Data.GainScore;

                if (Data.GainScore < 6)
                {
                    Data.Combo = 0;
                    ScoreSignals.Instance.onExitCombo?.Invoke();
                }
                else
                {
                    Data.Combo += 1;
                    if (Data.Combo == 1)
                    {
                        ScoreSignals.Instance.onExitCombo?.Invoke();
                    }
                    if (Data.Combo > 1 && Data.Combo < 3)
                    {
                        ScoreSignals.Instance.onExitCombo?.Invoke();
                        ScoreSignals.Instance.onCombo?.Invoke(0);
                    }

                    if (Data.Combo >= 3)
                    {
                        ScoreSignals.Instance.onExitCombo?.Invoke();
                        ScoreSignals.Instance.onCombo?.Invoke(1);
                    }
                    
                    if (Data.Combo> Data.MaxComboScore)
                    {
                        Data.MaxComboScore = Data.Combo;
                        UISignals.Instance.onSetMaxComboScore?.Invoke(Data.MaxComboScore);
                    }
                }
                
                UISignals.Instance.onSetScoreText?.Invoke(Data.Score);
                UISignals.Instance.onSetGainScoreText?.Invoke(Data.GainScore,Data.Combo);
                UISignals.Instance.onSetTimeSliderValue?.Invoke();
                Data.GainScore = 8;
            }

            if (Data.HighScore<Data.Score)
            {
                Data.HighScore = Data.Score;
                UISignals.Instance.onSetHighScoreText?.Invoke(Data.HighScore);
            }
        }
        
        private void OnComboDecrease()
        {
            Data.GainScore -= 2;
            
            if (Data.GainScore < 1)
            {
                Data.GainScore = 1;
            }
        }

        private void OnScoreGainBlocked()
        {
            _scoreIncreaseable = false;
        }
        
        private void OnReset()
        {
            Data.Score = 0;
            Data.GainScore = 8;
            Data.Combo = 0;
        }
    }
}