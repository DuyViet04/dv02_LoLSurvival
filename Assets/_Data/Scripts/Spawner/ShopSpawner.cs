using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShopSpawner : SpawnerSingleton<ShopSpawner>
{
    [SerializeField] private Transform player;

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

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayer();
    }

    void LoadPlayer()
    {
        if (this.player != null) return;
        this.player = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.LogWarning(this.transform.name + ": LoadPlayer", this.gameObject);
    }
}