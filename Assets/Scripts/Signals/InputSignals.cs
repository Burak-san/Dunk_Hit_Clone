using Extentions;
using UnityEngine.Events;

namespace Signals
{
    public class InputSignals : MonoSingleton<InputSignals>
    {
        public UnityAction onInputTaken = delegate {  };
        public UnityAction<bool> onCheckClickableInput = delegate { };
    }
}