using System;

namespace _Data.Refactor.Controllers.Animations
{
    public interface IEventController
    {
        public event Action OnEventEnd;
        public event Action OnEventStart;
        public void EventEnd();
        public void EventStart();
        
    }
}