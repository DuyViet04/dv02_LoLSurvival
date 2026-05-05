using System.Collections;
using Base.Systems.Spawner;
using UnityEngine;

namespace _Data.Refactor.Controllers.Spawners
{
    public class ShopSpawner : BaseSpawner
    {
        [Header("Spawn Settings")] [SerializeField]
        private float spawnTime;

        [SerializeField] private float spawnRange;
        [SerializeField] private float shopLifeTime = 60f;
        [SerializeField] private Transform player;
        private Transform activeShop;
        private float lifeTimer;

        void Start()
        {
            StartCoroutine(SpawnShop());
        }

        void Update()
        {
            if (activeShop == null) return;
            if (Time.timeScale <= 0) return;

            lifeTimer -= Time.deltaTime;
            if (lifeTimer <= 0)
            {
                Despawn(activeShop);
            }
        }

        IEnumerator SpawnShop()
        {
            while (true)
            {
                yield return new WaitForSeconds(spawnTime);
                if (activeShop != null) continue;

                Vector3 pos = GetRandomPosition();
                activeShop = Spawn("Shopkeeper", pos, Quaternion.identity);
                lifeTimer = shopLifeTime;
            }
        }

        Vector3 GetRandomPosition()
        {
            float x = Random.Range(-spawnRange, spawnRange);
            float z = Random.Range(-spawnRange, spawnRange);
            return player.position + new Vector3(x, 0, z);
        }

        public override void Despawn(Transform prefab)
        {
            base.Despawn(prefab);
            if (prefab == activeShop) activeShop = null;
        }
    }
}