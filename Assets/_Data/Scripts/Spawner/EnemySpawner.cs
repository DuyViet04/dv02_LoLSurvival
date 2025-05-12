using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    private static EnemySpawner instance;

    public static EnemySpawner Instance
    {
        get { return instance; }
    }

    [SerializeField] private float spawnTime = 1f;
    [SerializeField] private float spawnRange = 5f;
    private float spawnTimer = 0f;
    private string meleeEnemy = "MeleeEnemy";

    private void Awake()
    {
        if (instance != null) Debug.LogError("There is more than one Spawner in the scene!");
        instance = this;

        this.LoadPrefabs();
    }

    private void Update()
    {
        this.spawnTimer += Time.deltaTime;
        if (this.spawnTimer < this.spawnTime) return;
        this.spawnTimer = 0f;
        Spawn(this.meleeEnemy, this.GetRandomPosition(), Quaternion.identity);
    }

    Vector3 GetRandomPosition()
    {
        float x = Random.Range(this.spawnRange, -this.spawnRange);
        float z = Random.Range(this.spawnRange, -this.spawnRange);
        return new Vector3(x, 0, z);
    }
}