using System.Collections.Generic;
using _Data.Refactor.Models.SOs.Upgrades;
using _Data.Refactor.Models.SOs.Upgrades.Data;
using UnityEngine;

namespace _Data.Refactor.Models.Runtimes.Upgrades
{
    public class RarityRuntime
    {
        private readonly List<RarityData> rarities;

        public RarityRuntime(RaritySo baseSo)
        {
            rarities = new List<RarityData>(baseSo.rarities);
        }

        public RarityData GetRandomRarity()
        {
            float roll = Random.Range(0f, 1f);
            float cumulative = 0f;

            for (int i = 0; i < rarities.Count; i++)
            {
                cumulative += rarities[i].chance;
                if (roll <= cumulative) return rarities[i];
            }

            return rarities[0];
        }
    }
}