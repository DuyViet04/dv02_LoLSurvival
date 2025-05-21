using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    private static BulletSpawner instance;
    public static BulletSpawner Instance => instance;

    private void Awake()
    {
        if (instance != null) Debug.LogError("More than one instance of BulletSpawner");
        instance = this;
        
        this.LoadPrefabs();
    }
}