using UnityEngine;

namespace VyesBase.Systems.Combat
{
    public class CombatService : ICombatService
    {
        public float CalculateFinalDamage(DamageData rawDamage, BaseHealth target)
        {
            float amount = rawDamage.Amount;

            // 1. Tính toán chí mạng
            if (rawDamage.IsCritical)
            {
                amount *= 2f;
            }

            // 2. Tính toán giảm trừ theo hệ số phòng thủ
            float finalDamage = amount;
            switch (rawDamage.Type)
            {
                case DamageType.Physical:
                    finalDamage = CalculateReducedDamage(amount, target.Armor);
                    break;
                case DamageType.Magical:
                    finalDamage = CalculateReducedDamage(amount, target.MagicResistance);
                    break;
                case DamageType.Pure:
                    finalDamage = amount;
                    break;
            }

            return Mathf.Max(finalDamage, 0f);
        }

        private float CalculateReducedDamage(float damage, float resistance)
        {
            if (resistance >= 0)
            {
                return damage * (100f / (100f + resistance));
            }
            else
            {
                return damage * (2f - (100f / (100f - resistance)));
            }
        }
    }
}