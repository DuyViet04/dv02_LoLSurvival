using UnityEngine;

[System.Serializable]
public class ItemRarityData
{
    public ItemRarityType type;
    [Range(0f, 1f)] public float chance;
}
