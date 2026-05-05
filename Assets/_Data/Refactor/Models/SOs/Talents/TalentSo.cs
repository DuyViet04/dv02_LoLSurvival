using Base.Systems.Stat;
using UnityEngine;

namespace _Data.Refactor.Models.SOs.Talents
{
    [CreateAssetMenu(fileName = "TalentSo", menuName = "SOs/Talents/TalentSo")]
    public class TalentSo : ScriptableObject
    {
        public string talentId;
        public string talentName;
        public Sprite icon;
        [TextArea] public string description;

        [Header("Stat Settings")] public StatType statType;
        public ModifierType modifierType;
        public float baseValue;
        public float valuePerLevel;

        [Header("Cost Settings")] public int baseCost;
        public int costPerLevel;
        public int maxLevel;

        public int GetCost(int level)
        {
            return baseCost + (level * costPerLevel);
        }

        public int GetTotalCostToLevel(int level)
        {
            if (level <= 0) return 0;
            // Công thức tổng dãy số: n * base + costPerLevel * (n * (n-1) / 2)
            return level * baseCost + costPerLevel * (level * (level - 1) / 2);
        }

        public float GetEffectValue(int level)
        {
            return baseValue + (level * valuePerLevel);
        }
    }
}