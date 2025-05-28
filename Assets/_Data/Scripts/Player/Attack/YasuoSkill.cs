using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "YasuoSkill", menuName = "Skill/YasuoSkill")]
public class YasuoSkill : ScriptableObject
{
    public List<AttackData> yasuoSkillData;
    public int lastSkillIndex;

    private void Reset()
    {
        this.LoadData();
    }

    void LoadData()
    {
        this.AddData(AttackType.NormalAttack, DamageType.PhysicDamage, 20, 105, 0, true, 4);
        this.AddData(AttackType.Skill1, DamageType.PhysicDamage, 45, 105, 0, true, 12);
        this.AddData(AttackType.Skill2, DamageType.MagicDamage, 70, 20, 60, false, 10);
    }

    void AddData(AttackType atkType, DamageType damageType, float damage, float bonusAD, float bonusAP, bool isCritical,
        float cooldown)
    {
        AttackData attackData = new AttackData()
        {
            attackType = atkType,
            damageType = damageType,
            baseDamage = damage,
            bonusAD = bonusAD,
            bonusAP = bonusAP,
            isCritical = isCritical,
            cooldown = cooldown
        };
        this.yasuoSkillData.Add(attackData);
    }
}