using UnityEngine;

namespace VyesBase.Core.Architecture.Model
{
    public abstract class BaseSo : ScriptableObject
    {
        protected abstract void Init();

        public virtual BaseSoRuntime CreateRuntime()
        {
            return new BaseSoRuntime(this);
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            Init();
        }
#endif
    }
}