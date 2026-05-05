using _Data.Refactor.Enums;
using UnityEngine;

namespace _Data.Refactor.Models.SOs.Upgrades.Data
{
    [System.Serializable]
    public class RarityData
    {
        public RarityType rarity;
        public Color color;
        public int power;
        [Range(0f, 1f)] public float chance;

        public RarityData() { }

        public RarityData(RarityData other)
        {
            this.rarity = other.rarity;
            this.color = other.color;
            this.power = other.power;
            this.chance = other.chance;
        }
    }
}