using Signals;
using UnityEngine;

namespace Managers
{
    public class InputManager : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                InputSignals.Instance.onInputTaken?.Invoke();
            }
        }
    }
}