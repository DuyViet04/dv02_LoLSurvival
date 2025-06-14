using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TalentTable", menuName = "TalentTable")]
public class TalentTable : ScriptableObject
{
    public int csPoint;
    public List<TalentData> talents;

    void Reset()
    {
        this.talents.Clear();
        this.LoadData();
    }

    void LoadData()
    {
        this.AddTalent(SpriteFinder.GetStatIconSprite("Health"), UpgradeType.Health, 0, "Máu tối đa:", 0, 50);
        this.AddTalent(SpriteFinder.GetStatIconSprite("HealthRegen"), UpgradeType.HealthRegen, 0, "Hồi máu:", 0, 50);
        this.AddTalent(SpriteFinder.GetStatIconSprite("AttackDamage"), UpgradeType.AttackDamage, 0, "Sức mạnh vật lý:",
            0, 50);
        this.AddTalent(SpriteFinder.GetStatIconSprite("AbilityPower"), UpgradeType.AbilityPower, 0,
            "Sức mạnh phép thuật:", 0, 50);
        this.AddTalent(SpriteFinder.GetStatIconSprite("Armor"), UpgradeType.Armor, 0, "Giáp:", 0, 50);
        this.AddTalent(SpriteFinder.GetStatIconSprite("MagicResistance"), UpgradeType.MagicResistance, 0, "Kháng phép:",
            0, 50);
        this.AddTalent(SpriteFinder.GetStatIconSprite("MoveSpeed"), UpgradeType.MoveSpeed, 0, "Tốc độ di chuyển(%):", 0,
            50);
        this.AddTalent(SpriteFinder.GetStatIconSprite("CriticalChance"), UpgradeType.CriticalChance, 0,
            "Tỉ lệ chí mạng(%):", 0, 50);
        this.AddTalent(SpriteFinder.GetStatIconSprite("CriticalDamage"), UpgradeType.CriticalDamage, 0,
            "Sát thương chí mạng(%):", 0, 50);
        this.AddTalent(SpriteFinder.GetStatIconSprite("ArmorPenetration"), UpgradeType.ArmorPenetration, 0,
            "Xuyên giáp:", 0, 50);
        this.AddTalent(SpriteFinder.GetStatIconSprite("MagicPenetration"), UpgradeType.MagicPenetration, 0,
            "Xuyên kháng phép:", 0, 50);
        this.AddTalent(SpriteFinder.GetStatIconSprite("LifeSteal"), UpgradeType.LifeSteal, 0, "Hút máu(%):", 0, 50);
        this.AddTalent(SpriteFinder.GetStatIconSprite("Omnivamp"), UpgradeType.Omnivamp, 0, "Hút máu toàn phần(%):", 0,
            50);
        this.AddTalent(SpriteFinder.GetStatIconSprite("Haste"), UpgradeType.Haste, 0, "Hồi chiêu:", 0, 50);
        this.AddTalent(SpriteFinder.GetStatIconSprite("HealingPower"), UpgradeType.HealingPower, 0,
            "Sức mạnh hôì phục(%):", 0, 50);
        this.AddTalent(SpriteFinder.GetStatIconSprite("PickUpRange"), UpgradeType.PickUpRange, 0, "Tầm nhặt(%):", 0,
            50);
        this.AddTalent(SpriteFinder.GetStatIconSprite("ExpMultiplier"), UpgradeType.ExpMultiplier, 0, "Kinh nghiệm(%):",
            0, 50);
    }

    void AddTalent(Sprite icon, UpgradeType type, int currentLevel, string effectName, float effectValue,
        int pointCost)
    {
        TalentData talent = new TalentData
        {
            icon = icon,
            type = type,
            currentLevel = currentLevel,
            effectName = effectName,
            effectValue = effectValue,
            pointCost = pointCost
        };

        this.talents.Add(talent);
    }
}