using System;
using VyesBase.Utils;

namespace _Data.Refactor.Controllers.Animations
{
    public class AnimEventController : VyesBehaviour, IEventController
    {
        public event Action OnEventEnd;
        public event Action OnEventStart;

        public void EventEnd()
        {
            OnEventEnd?.Invoke();
        }

        public void EventStart()
        {
            OnEventStart?.Invoke();
        }
    }
}