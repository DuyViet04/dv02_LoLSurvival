using System;
using _Data.Refactor.Enums.Enemies;

namespace _Data.Refactor.Models.SOs.Enemies.Data
{
    [Serializable]
    public class EnemyData
    {
        public EnemyType Type { get; private set; }
        public float ExpValue { get; private set; }
        public float GoldValue { get; private set; }
        public float CsValue { get; private set; }
        public float SpawnDelay { get; private set; }
        public float SpawnCount { get; private set; }

        public EnemyData(EnemyData enemyData)
        {
            Type = enemyData.Type;
            ExpValue = enemyData.ExpValue;
            GoldValue = enemyData.GoldValue;
            CsValue = enemyData.CsValue;
            SpawnDelay = enemyData.SpawnDelay;
            SpawnCount = enemyData.SpawnCount;
        }
    }
}