using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TalentTable", menuName = "TalentTable")]
public class TalentTable : ScriptableObject
{
    public List<TalentData> attackTalent;
    public List<TalentData> defenseTalent;
    public List<TalentData> otherTalent;

    void LoadAttackTalent()
    {
        this.attackTalent.Add(AddData(SpriteFinder.GetStatIconSprite("AttackDamage"), UpgradeType.AttackDamage, 5));
        this.attackTalent.Add(AddData((SpriteFinder.GetStatIconSprite("AbilityPower")), UpgradeType.AbilityPower, 8));
        this.attackTalent.Add(AddData(SpriteFinder.GetStatIconSprite("CriticalChance"), UpgradeType.CriticalChance, 5));
        this.attackTalent.Add(AddData(SpriteFinder.GetStatIconSprite("CriticalDamage"), UpgradeType.CriticalDamage, 5));
        this.attackTalent.Add(AddData(SpriteFinder.GetStatIconSprite("ArmorPenetration"), UpgradeType.ArmorPenetration,
            5));
        this.attackTalent.Add(AddData(SpriteFinder.GetStatIconSprite("MagicPenetration"), UpgradeType.MagicPenetration,
            5));
        this.attackTalent.Add(AddData(SpriteFinder.GetStatIconSprite("Haste"), UpgradeType.Haste, 5));
    }

    void LoadDefenseTalent()
    {
        this.defenseTalent.Add(AddData(SpriteFinder.GetStatIconSprite("Health"), UpgradeType.Health, 50));
        this.defenseTalent.Add(AddData(SpriteFinder.GetStatIconSprite("HealthRegen"), UpgradeType.HealthRegen, 5));
        this.defenseTalent.Add(AddData(SpriteFinder.GetStatIconSprite("HealingPower"), UpgradeType.HealingPower, 5));
        this.defenseTalent.Add(AddData(SpriteFinder.GetStatIconSprite("Armor"), UpgradeType.Armor, 5));
        this.defenseTalent.Add(AddData(SpriteFinder.GetStatIconSprite("MagicResistance"), UpgradeType.MagicResistance,
            5));
        this.defenseTalent.Add(AddData(SpriteFinder.GetStatIconSprite("MoveSpeed"), UpgradeType.MoveSpeed, 5));
        this.defenseTalent.Add(AddData(SpriteFinder.GetStatIconSprite("LifeSteal"), UpgradeType.LifeSteal, 3));
        this.defenseTalent.Add(AddData(SpriteFinder.GetStatIconSprite("Omnivamp"), UpgradeType.Omnivamp, 5));
    }

    void LoadOtherTalent()
    {
        this.otherTalent.Add(AddData(SpriteFinder.GetStatIconSprite("PickUpRange"), UpgradeType.PickUpRange, 10));
        this.otherTalent.Add(AddData(SpriteFinder.GetStatIconSprite("ExpMultiplier"), UpgradeType.ExpMultiplier, 10));
    }

    TalentData AddData(Sprite icon, UpgradeType type, float value)
    {
        TalentData talentData = new TalentData
        {
            icon = icon,
            type = type,
            value = value
        };
        return talentData;
    }
}