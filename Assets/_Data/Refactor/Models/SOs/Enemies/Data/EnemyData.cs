using System;
using _Data.Refactor.Enums.Enemies;
using Base.Systems.Stat;
using UnityEngine;

namespace _Data.Refactor.Models.SOs.Enemies.Data
{
    [Serializable]
    public class EnemyData
    {
        [SerializeField] private EnemyType enemyType;
        [SerializeField] private Stat expValue;
        [SerializeField] private Stat goldValue;
        [SerializeField] private Stat csValue;
        [SerializeField] private Stat spawnDelay;
        [SerializeField] private Stat spawnCount;

        public EnemyType EnemyType => enemyType;
        public Stat ExpValue => expValue;
        public Stat GoldValue => goldValue;
        public Stat CsValue => csValue;
        public Stat SpawnDelay => spawnDelay;
        public Stat SpawnCount => spawnCount;

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