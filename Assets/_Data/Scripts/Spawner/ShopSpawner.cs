using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShopSpawner : Spawner
{
    private static ShopSpawner instance;

    public static ShopSpawner Instance => instance;

    [SerializeField] private Transform player;

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
        while (true)
        {
            yield return new WaitForSeconds(45);
            Vector3 pos = this.GetRandomPosition();

            Transform newShop = Spawn("Shopkeeper", pos, Quaternion.identity);
            Transform newArrow = Spawn("Arrow", this.player.position, Quaternion.identity);

            ArrowToShop arrowToShop = newArrow.gameObject.GetComponentInChildren<ArrowToShop>();
            arrowToShop.shopTransform = newShop.transform;
            arrowToShop.player.transform.position = this.player.position;
        }
    }

    Vector3 GetRandomPosition()
    {
        float range = 50f;
        float x = Random.Range(-range, range);
        float z = Random.Range(-range, range);
        return new Vector3(x, 0, z);
    }
}