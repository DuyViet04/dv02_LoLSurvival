using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "ItemRarityTable", menuName = "Item/RarityTable")]
public class ItemRarityTable : ScriptableObject
{
    public List<ItemRarityData> rarities;

    private void Reset()
    {
        this.LoadData();
    }

    public ItemRarityType GetRandomRarity()
    {
        float roll = Random.Range(0f, 1f);
        float cumulative = 0f;

        foreach (var r in this.rarities)
        {
            cumulative += r.chance;
            if (roll < cumulative)
            {
                return r.type;
            }
        }

        return ItemRarityType.Basic;
    }

    void LoadData()
    {
        AddData(ItemRarityType.Basic, 3f / 6f);
        AddData(ItemRarityType.Epic, 2f / 6f);
        AddData(ItemRarityType.Legendary, 1f / 6f);
    }

    void AddData(ItemRarityType type, float chance)
    {
        ItemRarityData data = new ItemRarityData();
        data.type = type;
        data.chance = chance;
        this.rarities.Add(data);
    }
}