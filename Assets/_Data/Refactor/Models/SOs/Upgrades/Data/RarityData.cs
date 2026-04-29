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
    }
}

