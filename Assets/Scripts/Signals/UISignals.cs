using Enums;
using Extentions;
using UnityEngine.Events;

namespace Signals
{
    public class UISignals : MonoSingleton<UISignals>
    {
        public UnityAction<UIPanels> onOpenPanel = delegate { };
        public UnityAction<UIPanels> onClosePanel = delegate { };
        public UnityAction onSetTimeSliderValue = delegate { };
        public UnityAction onCheckClickable = delegate { };
        public UnityAction<int> onSetScoreText = delegate {  };
        public UnityAction<int,int> onSetGainScoreText = delegate {  };
        public UnityAction<int> onSetHighScoreText = delegate {  };
        public UnityAction<int> onSetMaxComboScore = delegate {  };
    }
}