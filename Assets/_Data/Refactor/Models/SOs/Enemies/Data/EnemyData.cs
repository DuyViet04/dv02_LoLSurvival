using System;
using _Data.Refactor.Enums.Enemies;
using UnityEngine;

namespace _Data.Refactor.Models.SOs.Enemies.Data
{
    [Serializable]
    public class EnemyData
    {
        [SerializeField] private EnemyType enemyType;
        [SerializeField] private float expValue;
        [SerializeField] private float goldValue;
        [SerializeField] private float csValue;
        [SerializeField] private float spawnDelay;
        [SerializeField] private int spawnCount;

        public EnemyType EnemyType => enemyType;
        public float ExpValue => expValue;
        public float GoldValue => goldValue;
        public float CsValue => csValue;
        public float SpawnDelay => spawnDelay;
        public int SpawnCount => spawnCount;

        public EnemyData(EnemyData enemyData)
        {
            enemyType = enemyData.enemyType;
            expValue = enemyData.expValue;
            goldValue = enemyData.goldValue;
            csValue = enemyData.csValue;
            spawnDelay = enemyData.spawnDelay;
            spawnCount = enemyData.spawnCount;
        }
    }
}