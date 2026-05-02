using System;
using _Data.Refactor.Enums.Enemies;
using Base.Systems.Stat;
using UnityEngine;

namespace _Data.Refactor.Models.SOs.Enemies.Data
{
    [Serializable]
    public class EnemyData
    {
        [field: SerializeField] public EnemyType EnemyType { get; private set; }
        [field: SerializeField] public Stat ExpValue { get; private set; }
        [field: SerializeField] public Stat GoldValue { get; private set; }
        [field: SerializeField] public Stat CsValue { get; private set; }
        [field: SerializeField] public Stat SpawnDelay { get; private set; }
        [field: SerializeField] public Stat SpawnCount { get; private set; }

        public EnemyData(EnemyData enemyData)
        {
            EnemyType = enemyData.EnemyType;
            ExpValue = new Stat(enemyData.ExpValue);
            GoldValue = new Stat(enemyData.GoldValue);
            CsValue = new Stat(enemyData.CsValue);
            SpawnDelay = new Stat(enemyData.SpawnDelay);
            SpawnCount = new Stat(enemyData.SpawnCount);
        }
    }
}