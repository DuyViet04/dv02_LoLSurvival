using System.Collections;
using _Data.Refactor.Controllers.Enemies;
using _Data.Refactor.Managers;
using _Data.Refactor.States.Enemies;
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

        public int EnemyCount
        {
            get => enemyCount;
            set => enemyCount = value;
        }

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
                var enemies = SpawnMultiple(enemyName, GetRandomPosition(), Quaternion.identity, count);
                foreach (var item in enemies)
                {
                    item.gameObject.GetComponent<EnemyController>().MoveStateMachine.ChangeState(EnemyState.Chase);
                }

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