using VyesBase.Utils;
using VyesBase.Utils.GameLogger;

namespace VyesBase.Core.Singleton
{
    public class VyesSingleton<T> : VyesBehaviour where T : VyesBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameLogger.LogError($"{typeof(T)} not instantiated");
                }

                return _instance;
            }
        }

        protected override void LoadComponents()
        {
            base.LoadComponents();
            LoadInstance();
        }

        void LoadInstance()
        {
            if (_instance == null)
            {
                _instance = this as T;
            }
            else
            {
                GameLogger.LogError($"Only one instance of <color=yellow> {typeof(T)} </color> is allowed");
            }
        }
    }
}