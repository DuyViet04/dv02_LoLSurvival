using System.Collections;
using Base.Systems.Spawner;
using UnityEngine;

namespace _Data.Refactor.Controllers.Spawners
{
    public class ShopSpawner : BaseSpawner
    {
        [Header("Spawn Settings")]
        [SerializeField] private float spawnTime;
        [SerializeField] private float spawnRange;

        void Start()
        {
            StartCoroutine(SpawnShop());
        }

        IEnumerator SpawnShop()
        {
            while (true)
            {
                yield return new WaitForSeconds(spawnTime);
                Vector3 pos = GetRandomPosition();

                Transform newShop = Spawn("Shopkeeper", pos, Quaternion.identity);
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