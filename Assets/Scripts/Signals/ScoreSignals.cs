﻿using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class ScoreSignals : MonoSingleton<ScoreSignals>
    {
        public UnityAction onGainScore = delegate {  };
        public UnityAction onScoreIncreaseable = delegate {  };
        public UnityAction onScoreGainBlocked = delegate {  };
    }
}