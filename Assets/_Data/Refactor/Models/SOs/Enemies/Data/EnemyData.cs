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
            expValue = new Stat(enemyData.expValue);
            goldValue = new Stat(enemyData.goldValue);
            csValue = new Stat(enemyData.csValue);
            spawnDelay = new Stat(enemyData.spawnDelay);
            spawnCount = new Stat(enemyData.spawnCount);
        }
    }
}