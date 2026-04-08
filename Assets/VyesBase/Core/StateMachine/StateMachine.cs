using System.Collections.Generic;

namespace VyesBase.Core.StateMachine
{
    public class StateMachine<T>
    {
        private readonly Dictionary<T, IState> _states = new Dictionary<T, IState>();
        public T CurrentStateKey { get; private set; }
        public IState CurrentState { get; private set; }

        public void AddState(T key, IState state)
        {
            _states.Add(key, state);
        }

        public void SetInitState(T key)
        {
            ChangeState(key);
        }

        public void ChangeState(T key)
        {
            CurrentState?.OnExit();
            CurrentStateKey = key;
            CurrentState = _states[key];
            CurrentState.OnEnter();
        }

        public void UpdateSate()
        {
            CurrentState?.OnUpdate();
        }
    }
}