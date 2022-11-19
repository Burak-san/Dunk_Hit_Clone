using Enums;
using Signals;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers.UI
{
    public class GamePanelController : MonoBehaviour
    {
        [SerializeField] private Slider timeSlider;
        
        private bool _clickable = true;

        private void FixedUpdate()
        {
            if (_clickable)
            {
                SetTimeSliderValue();
            }
        }
        
        private void SetTimeSliderValue()
        {
            timeSlider.value -= 0.05f;
            if (timeSlider.value <= 0)
            {
                _clickable = false;
                InputSignals.Instance.onCheckClickableInput?.Invoke(_clickable);
            }
        }

        public void GainTimeSliderValue()
        {
            _clickable = true;
            InputSignals.Instance.onCheckClickableInput?.Invoke(_clickable);
            timeSlider.value = 10;
        }

        public void OnCheckClickable()
        {
            if (_clickable == false)
            {
                UISignals.Instance.onClosePanel?.Invoke(UIPanels.GamePanel);
                UISignals.Instance.onOpenPanel?.Invoke(UIPanels.FailPanel);
            }
        }

        public void SetGamePanel()
        {
            _clickable = true;
            timeSlider.value = 10;
        }
    }
}