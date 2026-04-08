using UnityEngine;

namespace VyesBase.Systems.Level
{
    public class LevelService : ILevelService
    {
        protected virtual float BaseXP => 100f;
        protected virtual float Multiplier => 1.1f;
        protected virtual int MaxLevelValue => 100;

        public virtual int MaxLevel => MaxLevelValue;

        public virtual float GetExpRequiredForLevel(int level)
        {
            if (level <= 1) return 0;
            if (level > MaxLevel) return float.MaxValue;
            
            return Mathf.Floor(BaseXP * Mathf.Pow(Multiplier, level - 2));
        }

        public virtual bool CanLevelUp(int currentLevel, float currentExp)
        {
            if (currentLevel >= MaxLevel) return false;
            
            float requiredExp = GetExpRequiredForLevel(currentLevel + 1);
            return currentExp >= requiredExp;
        }
    }
}
