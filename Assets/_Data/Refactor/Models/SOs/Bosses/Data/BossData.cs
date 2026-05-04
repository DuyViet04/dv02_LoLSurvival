using System;
using _Data.Refactor.Enums.Bosses;
using UnityEngine;

namespace _Data.Refactor.Models.SOs.Bosses.Data
{
    [Serializable]
    public class BossData
    {
        [field: SerializeField] public BossType BossType { get; private set; }

        public BossData(BossData bossData)
        {
            BossType = bossData.BossType;
        }
    }
}
