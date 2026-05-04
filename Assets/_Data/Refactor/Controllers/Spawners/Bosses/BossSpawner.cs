using System.Collections.Generic;
using System.Collections;
using Base.Systems.Spawner;
using UnityEngine;

namespace _Data.Refactor.Controllers.Spawners.Bosses
{
    public class BossSpawner : BaseSpawner
    {
        [SerializeField] private string bossName = "BossAatrox";
        [SerializeField] private float spawnDelay = 900f;

        private void Start()
        {
            StartCoroutine(SpawnBossTimer());
        }

        private IEnumerator SpawnBossTimer()
        {
            yield return new WaitForSeconds(spawnDelay);
            SpawnBoss();
        }

        public void SpawnBoss()
        {
            Spawn(bossName, transform.position, Quaternion.identity);
        }
    }
}