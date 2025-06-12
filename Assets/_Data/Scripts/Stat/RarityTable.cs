using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "RarityTable", menuName = "RarityTable")]
public class RarityTable : ScriptableObject
{
    public List<RarityData> rarities;

    private void Reset()
    {
        this.rarities.Clear();
        this.LoadData();
    }

    public void ResetRarityTable()
    {
        this.rarities.Clear();
        this.LoadData();
    }

    public RarityType GetRandomRarity()
    {
        float roll = Random.Range(0f, 1f);
        float cumulative = 0f;

        foreach (var r in rarities)
        {
            cumulative += r.chance;
            if (roll <= cumulative)
                return r.rarity;
        }

        return rarities[0].rarity;
    }

    public Color GetColorByRarity(RarityType rarity)
    {
        return rarities.FirstOrDefault(r => r.rarity == rarity)?.color ?? Color.white;
    }

    public int GetPowerByRarity(RarityType rarity)
    {
        return rarities.FirstOrDefault(r => r.rarity == rarity)?.power ?? 1;
    }

    void LoadData()
    {
        this.AddRarityData(RarityType.Common, Color.white, 1, 1);
        this.AddRarityData(RarityType.Uncommon, Color.green, 2, 0);
        this.AddRarityData(RarityType.Rare, Color.blue, 3, 0);
        this.AddRarityData(RarityType.Epic, Color.magenta, 4, 0);
        this.AddRarityData(RarityType.Legendary, Color.yellow, 5, 0);
    }

    void AddRarityData(RarityType rarity, Color color, int power, float change)
    {
        RarityData rarityData = new RarityData
        {
            rarity = rarity,
            color = color,
            power = power,
            chance = change
        };

        rarities.Add(rarityData);
    }
}