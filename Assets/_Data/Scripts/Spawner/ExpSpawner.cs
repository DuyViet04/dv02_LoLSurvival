using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpSpawner : Spawner
{
    private static ExpSpawner instance;

    public static ExpSpawner Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null) Debug.LogError("More than one instance of ExpSpawner");
        instance = this;
        
        this.LoadPrefabs();
    }
}