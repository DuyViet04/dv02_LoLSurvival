using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeData", menuName = "UpgradeData")]
public class UpgradeTable : ScriptableObject
{
    public List<UpgradeData> upgrades;

    private void Reset()
    {
        this.upgrades.Clear();
        this.LoadData();
    }

    void LoadData()
    {
        this.AddUpgrade(SpriteFinder.GetStatIconSprite("Health"), UpgradeType.Health, "Máu tối đa:", 75);
        this.AddUpgrade(SpriteFinder.GetStatIconSprite("HealthRegen"), UpgradeType.HealthRegen, "Hồi máu:", 5);
        this.AddUpgrade(SpriteFinder.GetStatIconSprite("AttackDamage"), UpgradeType.AttackDamage, "Sức mạnh vật lý:",
            7);
        this.AddUpgrade(SpriteFinder.GetStatIconSprite("AbilityPower"), UpgradeType.AbilityPower,
            "Sức mạnh phép thuật:", 7);
        this.AddUpgrade(SpriteFinder.GetStatIconSprite("Armor"), UpgradeType.Armor, "Giáp:", 9);
        this.AddUpgrade(SpriteFinder.GetStatIconSprite("MagicResistance"), UpgradeType.MagicResistance, "Kháng phép:",
            9);
        this.AddUpgrade(SpriteFinder.GetStatIconSprite("MoveSpeed"), UpgradeType.MoveSpeed, "Tốc độ di chuyển(%):", 4);
        this.AddUpgrade(SpriteFinder.GetStatIconSprite("CriticalChance"), UpgradeType.CriticalChance,
            "Tỉ lệ chí mạng(%):", 5);
        this.AddUpgrade(SpriteFinder.GetStatIconSprite("CriticalDamage"), UpgradeType.CriticalDamage,
            "Sát thương chí mạng(%):", 5);
        this.AddUpgrade(SpriteFinder.GetStatIconSprite("ArmorPenetration"), UpgradeType.ArmorPenetration, "Xuyên giáp:",
            4);
        this.AddUpgrade(SpriteFinder.GetStatIconSprite("MagicPenetration"), UpgradeType.MagicPenetration,
            "Xuyên kháng phép:", 4);
        this.AddUpgrade(SpriteFinder.GetStatIconSprite("LifeSteal"), UpgradeType.LifeSteal, "Hút máu(%):", 3);
        this.AddUpgrade(SpriteFinder.GetStatIconSprite("Omnivamp"), UpgradeType.Omnivamp, "Hút máu toàn phần(%):", 5);
        this.AddUpgrade(SpriteFinder.GetStatIconSprite("Haste"), UpgradeType.Haste, "Hồi chiêu:", 7);
        this.AddUpgrade(SpriteFinder.GetStatIconSprite("HealingPower"), UpgradeType.HealingPower,
            "Sức mạnh hôì phục(%):", 5);
        this.AddUpgrade(SpriteFinder.GetStatIconSprite("PickUpRange"), UpgradeType.PickUpRange, "Tầm nhặt(%):", 10);
        this.AddUpgrade(SpriteFinder.GetStatIconSprite("ExpMultiplier"), UpgradeType.ExpMultiplier, "Kinh nghiệm(%): ",
            5);
    }

    void AddUpgrade(Sprite icon, UpgradeType type, string upgName, float value)
    {
        UpgradeData upgrade = new UpgradeData
        {
            icon = icon,
            type = type,
            name = upgName,
            value = value
        };

        this.upgrades.Add(upgrade);
    }
}