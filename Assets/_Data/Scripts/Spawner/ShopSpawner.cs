using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShopSpawner : Spawner
{
    private static ShopSpawner instance;

    public static ShopSpawner Instance => instance;

    private void Awake()
    {
        if (instance != null) Debug.LogError("More than one instance of ExpSpawner");
        instance = this;

        this.LoadPrefabs();
    }

    private void Start()
    {
        StartCoroutine(SpawnShop());
    }

    IEnumerator SpawnShop()
    {
        yield return new WaitForSeconds(45);
        Vector3 pos = this.GetRandomPosition();
        Spawn("Shopkeeper", pos, Quaternion.identity);
    }

    Vector3 GetRandomPosition()
    {
        float range = 70f;
        float x = Random.Range(-range, range);
        float z = Random.Range(-range, range);
        return new Vector3(x, 0, z);
    }
}