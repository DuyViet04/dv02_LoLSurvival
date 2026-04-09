using UnityEngine;

namespace _Data.Refactor.Models.SOs.Players
{
    [CreateAssetMenu(fileName = "YasuoSo", menuName = "SOs/Players/YasuoSo")]
    public class YasuoSo : BasePlayerSo
    {
        protected override void Init()
        {
            characterName = "Yasuo";
            health = 590f;
            healthRegen = 5f;
            attackDamage = 60f;
            abilityPower = 0;
            armor = 32f;
            magicResistance = 32f;
            moveSpeed = 3.45f;
            criticalChance = 0f;
            criticalDamage = 175;
            armorPenetration = 0f;
            magicPenetration = 0f;
            lifeSteal = 0f;
            omnivamp = 0f;
            haste = 0f;
            healingPower = 0f;
            pickUpRange = 1f;
            expMultiplier = 0f;
        }
    }
}