using System;
using Data.ValueObjects;
using Signals;
using UnityEngine;

namespace Managers
{
    public class ScoreManager : MonoBehaviour
    {
        public ScoreData Data;
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
                // UI SİNYALE İNVOKE ATILACAK
                // SCORE KAYDEDİLECEK
                // KALAN ZAMAN FULLENECEK
                // CORE GAME SİNYALE İNVOKE ATILACAK HOOP DİNLEYİP DOTWEEN İLE HAREKET EDECEK VE ROPE HAREKET EDECEK
                // ROPE HAREKETİNDE SCRİPTABLE İÇİNE ROPE SPRİTE LİSTESİ EKLENECEK COROUTİNE İLE DÖNÜLECEK DATADAN ÇEKİLECEK
                //OPSİYONEL OLARAK SCORE COMBO YAPILACAK HOOP MATERİAL DEĞİŞİMİ OPSİYONEL
            }
        }
        
        private void OnScoreGainBlocked()
        {
            _scoreIncreaseable = false;
        }
    }
}