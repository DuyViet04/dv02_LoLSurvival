using UnityEngine;

namespace VyesBase.Core.Architecture.Model
{
    public abstract class BaseSo : ScriptableObject
    {
        protected void Reset()
        {
            Init();
        }

        protected abstract void Init();
        public abstract BaseSoRuntime CreateRuntime();

#if UNITY_EDITOR
        private void OnValidate()
        {
            Init();
        }
#endif
    }
}