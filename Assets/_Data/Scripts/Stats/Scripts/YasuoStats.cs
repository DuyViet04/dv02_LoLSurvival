using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "YasuoStats", menuName = "Stats/Yasuo")]
public class YasuoStats : MainCharacterStats
{
    private void Reset()
    {
        this.characterName = "Yasuo";
        this.health = 590f;
        this.healthRegen = 2f;
        this.attackDamage = 60f;
        this.abilityPower = 0;
        this.attackSpeed = 0.7f;
        this.armor = 32f;
        this.magicResistance = 32f;
        this.moveSpeed = 3.45f;
        this.criticalChance = 0f;
        this.criticalDamage = 175 * 0.9f;
        this.armorPenetration = 0f;
        this.magicPenetration = 0f;
        this.lifeSteal = 0f;
        this.omnivamp = 0f;
        this.haste = 0f;
        this.healingPower = 0f;
        this.pickUpRange = 0.5f;
    }

    public void ResetStats()
    {
        this.characterName = "Yasuo";
        this.health = 590f;
        this.healthRegen = 2f;
        this.attackDamage = 60f;
        this.abilityPower = 0;
        this.attackSpeed = 0.7f;
        this.armor = 32f;
        this.magicResistance = 32f;
        this.moveSpeed = 3.45f;
        this.criticalChance = 0f;
        this.criticalDamage = 175 * 0.9f;
        this.armorPenetration = 0f;
        this.magicPenetration = 0f;
        this.lifeSteal = 0f;
        this.omnivamp = 0f;
        this.haste = 0f;
        this.healingPower = 0f;
        this.pickUpRange = 0.5f;
    }

    public YasuoStats Clone()
    {
        return Instantiate(this);
    }

    public void ApplyUpgrade(UpgradeType type, float value)
    {
        switch (type)
        {
            case UpgradeType.Health:
                this.health += value;
                break;
            case UpgradeType.HealthRegen:
                this.healthRegen += value;
                break;
            case UpgradeType.AttackDamage:
                this.attackDamage += value;
                break;
            case UpgradeType.AbilityPower:
                this.abilityPower += value;
                break;
            case UpgradeType.AttackSpeed:
                this.attackSpeed += this.attackSpeed * (value / 100f);
                break;
            case UpgradeType.Armor:
                this.armor += value;
                break;
            case UpgradeType.MagicResistance:
                this.magicResistance += value;
                break;
            case UpgradeType.MoveSpeed:
                this.moveSpeed += this.moveSpeed * (value / 100f);
                break;
            case UpgradeType.CriticalChance:
                this.criticalChance += value;
                break;
            case UpgradeType.CriticalDamage:
                this.criticalDamage += value;
                break;
            case UpgradeType.ArmorPenetration:
                this.armorPenetration += value;
                break;
            case UpgradeType.MagicPenetration:
                this.magicPenetration += value;
                break;
            case UpgradeType.LifeSteal:
                this.lifeSteal += value;
                break;
            case UpgradeType.Omnivamp:
                this.omnivamp += value;
                break;
            case UpgradeType.Haste:
                this.haste += value;
                break;
            case UpgradeType.HealingPower:
                this.healingPower += value;
                break;
        }
    }
}