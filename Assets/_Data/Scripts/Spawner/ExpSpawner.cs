using UnityEngine;

public class ExpSpawner : Spawner
{
    private static ExpSpawner instance;

    public static ExpSpawner Instance => instance;

    private void Awake()
    {
        if (instance != null) Debug.LogError("More than one instance of ExpSpawner");
        instance = this;

        this.LoadPrefabs();
    }
}