using UnityEngine;

[System.Serializable]
public class RarityData
{
    public RarityType rarity;
    public Color color;
    public int power;
    [Range(0f, 1f)] public float change;
}

