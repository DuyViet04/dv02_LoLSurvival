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
        this.AddUpgrade(UpgradeType.Health, "Máu tối đa:", 75);
        this.AddUpgrade(UpgradeType.HealthRegen, "Hồi máu:", 2);
        this.AddUpgrade(UpgradeType.AttackDamage, "Sức mạnh vật lý:", 7);
        this.AddUpgrade(UpgradeType.AbilityPower, "Sức mạnh phép thuật:", 7);
        this.AddUpgrade(UpgradeType.Armor, "Giáp:", 9);
        this.AddUpgrade(UpgradeType.MagicResistance, "Kháng phép:", 9);
        this.AddUpgrade(UpgradeType.MoveSpeed, "Tốc độ di chuyển(%):", 4);
        this.AddUpgrade(UpgradeType.CriticalChance, "Tỉ lệ chí mạng(%):", 5);
        this.AddUpgrade(UpgradeType.CriticalDamage, "Sát thương chí mạng(%):", 5);
        this.AddUpgrade(UpgradeType.ArmorPenetration, "Xuyên giáp:", 4);
        this.AddUpgrade(UpgradeType.MagicPenetration, "Xuyên kháng phép:", 4);
        this.AddUpgrade(UpgradeType.LifeSteal, "Hút máu(%):", 3);
        this.AddUpgrade(UpgradeType.Omnivamp, "Hút máu toàn phần(%):", 5);
        this.AddUpgrade(UpgradeType.Haste, "Hồi chiêu:", 7);
        this.AddUpgrade(UpgradeType.HealingPower, "Sức mạnh hôì phục(%):", 5);
        this.AddUpgrade(UpgradeType.PickUpRange, "Tầm nhặt(%):", 10);
        this.AddUpgrade(UpgradeType.ExpMultiplier, "Kinh nghiệm(%): ", 5);
    }

    void AddUpgrade(UpgradeType type, string upgName, float value)
    {
        UpgradeData upgrade = new UpgradeData
        {
            type = type,
            name = upgName,
            value = value
        };

        this.upgrades.Add(upgrade);
    }
}