using System;

namespace VyesBase.Core.Architecture.Interfaces
{
    public interface IEventController
    {
        public event Action OnEventEnd;
        public event Action OnEventStart;
        public void EventEnd();
        public void EventStart();
        
    }
}