using Extentions;
using UnityEngine.Events;

namespace Signals
{
    public class ScoreSignals : MonoSingleton<ScoreSignals>
    {
        public UnityAction onGainScore = delegate {  };
        public UnityAction onScoreIncreaseable = delegate {  };
        public UnityAction onScoreGainBlocked = delegate {  };
        public UnityAction onComboValueDecrease = delegate {  };
        public UnityAction<int> onCombo = delegate {  };
        public UnityAction onExitCombo = delegate {  };
    }
}