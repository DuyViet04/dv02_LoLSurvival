using UnityEngine;

public abstract class VyesSingleton<T> : VyesBehaviour where T : VyesBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null) Debug.LogError("VyesSingleton<" + typeof(T).Name + "> is null");
            return _instance;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        this.LoadInstance();
    }

    protected override void Reset()
    {
        base.Reset();
        _instance = this as T;
    }

    void LoadInstance()
    {
        if (_instance == null)
        {
            _instance = this as T;
        }

        if (_instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
    }
}