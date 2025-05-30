public class VyesPersistentSingleton<T> : VyesSingleton<T> where T : VyesBehaviour
{
    protected override void Awake()
    {
        base.Awake();
        if (Instance == this)
        {
            DontDestroyOnLoad(this);
        }
    }
}