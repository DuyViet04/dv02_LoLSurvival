using UnityEngine;

namespace VyesBase.Core.Singleton
{
    public class VyesPersistentSingleton<T> : VyesSingleton<T> where T : MonoBehaviour
    {
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }
    }
}