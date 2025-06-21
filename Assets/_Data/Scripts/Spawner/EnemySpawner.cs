using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : SpawnerSingleton<EnemySpawner>
{
    [SerializeField] private float spawnRange = 10f;
    private List<MainEnemyStats> enemyStatsList;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.enemyStatsList = SOManager.Instance.GetEnemyStatsList();
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
        if (this.spawnRange < 60f)
        {
            this.spawnRange += Time.deltaTime;
        }
        else
        {
            this.spawnRange = 60f;
        }
    }

    IEnumerator SpawnEnemy(MainEnemyStats enemyStats)
    {
        while (true)
        {
            yield return new WaitForSeconds(enemyStats.spawnDelay);
            Spawn(enemyStats.type.ToString(), this.GetRandomPosition(), Quaternion.identity, enemyStats.spawnCount);
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
        CSDisplay.Instance.IncreaseCsCount();
    }
}