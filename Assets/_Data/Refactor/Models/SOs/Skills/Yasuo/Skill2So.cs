using _Data.Refactor.Enums.Skills;
using UnityEngine;

namespace _Data.Refactor.Models.SOs.Skills.Yasuo
{
    [CreateAssetMenu(fileName = "Skill1So", menuName = "SOs/Skills/Yasuo/Skill1So")]
    public class Skill1So : BasePlayerSkillSo
    {
        protected override void Init()
        {
            skillType = SkillType.Skill1;
            damageType = DamageType.PhysicDamage;
            baseDamage = 45;
            bonusAd = 105;
            canCrit = true;
            cooldown = 12;
        }
    }
}