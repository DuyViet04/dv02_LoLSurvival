using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BossAatroxSkill", menuName = "Skill/Boss/BossAatroxSkill")]
public class BossAatroxSkill : ScriptableObject
{
    public List<AttackData> bossAatroxSkillData;

    private void Reset()
    {
        this.LoadData();
    }

    void LoadData()
    {
        this.AddData(AttackType.Skill1, DamageType.PhysicDamage, 10, 60, 0, true, 12);
        this.AddData(AttackType.Skill1_1, DamageType.PhysicDamage, 12.5f, 75, 0, true, 0);
        this.AddData(AttackType.Skill1_2, DamageType.PhysicDamage, 15, 90, 0, true, 0);
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
        this.bossAatroxSkillData.Add(attackData);
    }
}