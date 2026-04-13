using System;
using VyesBase.Core.Architecture.Interfaces;
using VyesBase.Utils;

namespace VyesBase.Systems.Animation
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