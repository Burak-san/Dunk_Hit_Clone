using System;
using System.Collections.Generic;
using Controllers.Hoop;
using Signals;
using UnityEngine;

namespace Managers
{
    public class HoopManager : MonoBehaviour
    {
        public List<HoopMovementController> hoops;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            
        }

        #region Event Subscriptions

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onReset += OnReset;
        }

        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onReset -= OnReset;
        }
        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        #endregion
        
        private void OnPlay()
        {
            
        }
        

        private void OnReset()
        {
        }
    }
}