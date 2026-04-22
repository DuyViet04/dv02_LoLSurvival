using System.Collections;
using _Data.Refactor.Managers;
using Base.Systems.Spawner;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Data.Refactor.Controllers.Spawners
{
    public class EnemySpawner : BaseSpawner
    {
        [SerializeField] private float spawnRange;
        [SerializeField] private int maxEnemies = 100;

        private int enemyCount;

        private void Start()
        {
            var enemySos = SoManager.Ins.EnemySos;
            // Debug.Log($"EnemySos count: {enemySos.Count}");
            foreach (var enemySo in enemySos)
            {
                string enemyName = enemySo.enemyData.EnemyType.ToString();
                float delay = enemySo.enemyData.SpawnDelay;
                int count = enemySo.enemyData.SpawnCount;
                StartCoroutine(Spawn(enemyName, delay, count));
            }
        }

        private void Update()
        {
            if (spawnRange > 60f) return;
            spawnRange += Time.deltaTime;
        }

        IEnumerator Spawn(string enemyName, float delay, int count)
        {
            while (true)
            {
                yield return new WaitForSeconds(delay);
                yield return new WaitUntil(() => enemyCount < maxEnemies);
                SpawnMultiple(enemyName, GetRandomPosition(), Quaternion.identity, count);
                enemyCount += count;
            }
        }

        Vector3 GetRandomPosition()
        {
            float x = Random.Range(-spawnRange, spawnRange);
            float z = Random.Range(-spawnRange, spawnRange);
            return new Vector3(x, 0, z);
        }
    }
}