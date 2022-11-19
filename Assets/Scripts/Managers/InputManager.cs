using System;
using Signals;
using UnityEngine;

namespace Managers
{
    public class InputManager : MonoBehaviour
    {
        private bool _clickable = true;
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (_clickable)
                {
                    InputSignals.Instance.onInputTaken?.Invoke();
                }
            }
        }

        #region Event Subscriptions

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            InputSignals.Instance.onCheckClickableInput += OnCheckClickableInput;

            CoreGameSignals.Instance.onReset += OnReset;
        }
        
        private void UnSubscribeEvents()
        {
            InputSignals.Instance.onCheckClickableInput -= OnCheckClickableInput;
            
            CoreGameSignals.Instance.onReset -= OnReset;
        }

        

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        #endregion

        private void OnCheckClickableInput(bool clickable)
        {
            _clickable = clickable;
        }
        
        private void OnReset()
        {
            _clickable = true;
        }
    }
}