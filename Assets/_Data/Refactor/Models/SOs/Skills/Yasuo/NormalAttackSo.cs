using _Data.Refactor.Enums.Skills;
using UnityEngine;

namespace _Data.Refactor.Models.SOs.Skills.Yasuo
{
    [CreateAssetMenu(fileName = "NormalAttackSo", menuName = "SOs/Skills/Yasuo/NormalAttackSo")]
    public class NormalAttackSo : BasePlayerSkillSo
    {
        protected override void Init()
        {
            skillType = SkillType.NormalAttack;
            damageType = DamageType.PhysicDamage;
            baseDamage = 20f;
            bonusAd = 105f;
            canCrit = true;
            cooldown = 4f;
        }
    }
}