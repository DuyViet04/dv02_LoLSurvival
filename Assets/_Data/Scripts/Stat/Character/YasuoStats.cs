using UnityEngine;

[CreateAssetMenu(fileName = "YasuoStats", menuName = "Stats/Yasuo")]
public class YasuoStats : MainCharacterStats
{
    private float baseMoveSpeed;
    private float basePickUpRange;

    private void Reset()
    {
        this.characterName = "Yasuo";
        this.health = 590f;
        this.healthRegen = 5f;
        this.attackDamage = 60f;
        this.abilityPower = 0;
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
        this.pickUpRange = 1f;
        this.expMultiplier = 0f;
    }

    public void ResetToBaseStats()
    {
        this.characterName = "Yasuo";
        this.health = 590f;
        this.healthRegen = 5f;
        this.attackDamage = 60f;
        this.abilityPower = 0;
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
        this.pickUpRange = 1f;
        this.expMultiplier = 0f;

        this.baseMoveSpeed = this.moveSpeed;
        this.basePickUpRange = this.pickUpRange;
    }

    public void ResetStats(TalentTable talentTable)
    {
        this.characterName = "Yasuo";
        this.health = 590f + talentTable.talents[0].effectValue;
        this.healthRegen = 5f + talentTable.talents[1].effectValue;
        this.attackDamage = 60f + talentTable.talents[2].effectValue;
        this.abilityPower = 0 + talentTable.talents[3].effectValue;
        this.armor = 32f + talentTable.talents[4].effectValue;
        this.magicResistance = 32f + talentTable.talents[5].effectValue;
        this.moveSpeed = 3.45f + (3.45f * (talentTable.talents[6].effectValue / 100f));
        this.criticalChance = 0f + (talentTable.talents[7].effectValue * 2);
        this.criticalDamage = (175 * 0.9f) + (talentTable.talents[8].effectValue * 0.9f);
        this.armorPenetration = 0f + talentTable.talents[9].effectValue;
        this.magicPenetration = 0f + talentTable.talents[10].effectValue;
        this.lifeSteal = 0f + talentTable.talents[11].effectValue;
        this.omnivamp = 0f + talentTable.talents[12].effectValue;
        this.haste = 0f + talentTable.talents[13].effectValue;
        this.healingPower = 0f + talentTable.talents[14].effectValue;
        this.pickUpRange = 1f + (1f * (talentTable.talents[15].effectValue / 100f));
        this.expMultiplier = 0f + talentTable.talents[16].effectValue;
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
            case UpgradeType.Armor:
                this.armor += value;
                break;
            case UpgradeType.MagicResistance:
                this.magicResistance += value;
                break;
            case UpgradeType.MoveSpeed:
                this.moveSpeed += baseMoveSpeed * (value / 100f);
                break;
            case UpgradeType.CriticalChance:
                this.criticalChance += value * 2;
                if (this.criticalChance > 100f)
                {
                    float balance = this.criticalChance - 100f;
                    this.attackDamage += balance * 0.5f;
                    this.criticalChance = 100f;
                }

                break;
            case UpgradeType.CriticalDamage:
                this.criticalDamage += value * 0.9f;
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
            case UpgradeType.PickUpRange:
                this.pickUpRange += this.basePickUpRange * (value / 100f);
                break;
            case UpgradeType.ExpMultiplier:
                this.expMultiplier += value;
                break;
        }
    }

    private void RemoveUpgrade(UpgradeType type, float value)
    {
        switch (type)
        {
            case UpgradeType.Health:
                this.health -= value;
                break;
            case UpgradeType.HealthRegen:
                this.healthRegen -= value;
                break;
            case UpgradeType.AttackDamage:
                this.attackDamage -= value;
                break;
            case UpgradeType.AbilityPower:
                this.abilityPower -= value;
                break;
            case UpgradeType.Armor:
                this.armor -= value;
                break;
            case UpgradeType.MagicResistance:
                this.magicResistance -= value;
                break;
            case UpgradeType.MoveSpeed:
                this.moveSpeed -= baseMoveSpeed * (value / 100f);
                break;
            case UpgradeType.CriticalChance:
                this.criticalChance -= value * 2;
                if (this.criticalChance < 0f)
                {
                    this.criticalChance = 0f;
                }

                break;
            case UpgradeType.CriticalDamage:
                this.criticalDamage -= value * 0.9f;
                break;
            case UpgradeType.ArmorPenetration:
                this.armorPenetration -= value;
                break;
            case UpgradeType.MagicPenetration:
                this.magicPenetration -= value;
                break;
            case UpgradeType.LifeSteal:
                this.lifeSteal -= value;
                break;
            case UpgradeType.Omnivamp:
                this.omnivamp -= value;
                break;
            case UpgradeType.Haste:
                this.haste -= value;
                break;
            case UpgradeType.HealingPower:
                this.healingPower -= value;
                break;
        }
    }

    public void ApplyItem(ItemData item)
    {
        foreach (var effect in item.effects)
        {
            ApplyUpgrade(effect.type, effect.value);
        }
    }

    public void RemoveItem(ItemData item)
    {
        foreach (var effect in item.effects)
        {
            RemoveUpgrade(effect.type, effect.value);
        }
    }
}