using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : Spawner
{
    private static EnemySpawner instance;

    public static EnemySpawner Instance => instance;

    [SerializeField] private CSDisplay display;
    [SerializeField] private float spawnRange = 10f;
    private SOManager soManager;
    private List<MainEnemyStats> enemyStatsList;

    private void Awake()
    {
        if (instance != null) Debug.LogError("There is more than one Spawner in the scene!");
        instance = this;

        this.LoadPrefabs();
        this.soManager = FindObjectOfType<SOManager>();
        this.enemyStatsList = this.soManager.GetEnemyStatsList();
    }

    private void Start()
    {
        foreach (MainEnemyStats item in this.enemyStatsList)
        {
            StartCoroutine(SpawnEnemy(item));
        }
    }

    private void Update()
    {
        if (this.spawnRange < 70f)
        {
            this.spawnRange += Time.deltaTime;
        }
        else
        {
            this.spawnRange = 70f;
        }
    }

    IEnumerator SpawnEnemy(MainEnemyStats enemyStats)
    {
        while (true)
        {
            Spawn(enemyStats.type.ToString(), this.GetRandomPosition(), Quaternion.identity, enemyStats.spawnCount);
            yield return new WaitForSeconds(enemyStats.spawnDelay);
        }
    }

    Vector3 GetRandomPosition()
    {
        float x = Random.Range(this.spawnRange, -this.spawnRange);
        float z = Random.Range(this.spawnRange, -this.spawnRange);
        return new Vector3(x, 0, z);
    }

    public override void Despawn(Transform prefab)
    {
        base.Despawn(prefab);
        this.display.IncreaseCsCount();
    }
}