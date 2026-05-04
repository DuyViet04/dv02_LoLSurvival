using Base.Utilities;
using UnityEngine;

namespace _Data.Scripts.Spawner
{
    public abstract class SpawnerSingleton<T> : Spawner where T : VyesBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null) Debug.LogError("SpawnerSingleton<" + typeof(T).Name + "> is null");
                return _instance;
            }
        }

        protected override void Awake()
        {
            base.Awake();
            this.LoadInstance();
        }

        void LoadInstance()
        {
            if (_instance == null)
            {
                _instance = this as T;
            }

            if (_instance != this)
                Debug.LogError("SpawnerSingleton<" + typeof(T).Name + "> already exists.");
        }
    }
}