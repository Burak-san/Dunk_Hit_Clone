using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Controllers;
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
        }
        
        private void UnSubscribeEvents()
        {
            InputSignals.Instance.onInputTaken -= OnInputTaken;
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
    }
}

