namespace VyesBase.Core.Singleton
{
    public class VyesPersistentSingleton<T> : VyesSingleton<T> where T : VyesBehaviour
    {
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }
    }
}