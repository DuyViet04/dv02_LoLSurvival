using _Data.Refactor.Enums.Skills;
using UnityEngine;

namespace _Data.Refactor.Models.SOs.Skills.Yasuo
{
    [CreateAssetMenu(fileName = "Skill2So", menuName = "SOs/Skills/Yasuo/Skill2So")]
    public class Skill2So : BasePlayerSkillSo
    {
        protected override void Init()
        {
            skillType = SkillType.Skill2;
            damageType = DamageType.MagicDamage;
            baseDamage = 70;
            bonusAd = 20;
            bonusAp = 60;
            canCrit = false;
            cooldown = 10;
        }
    }
}