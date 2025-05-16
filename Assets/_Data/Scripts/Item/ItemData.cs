using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Item/NewItem")]
public class ItemData : ScriptableObject
{
    public ItemType type;
    public ItemRarityType rarity;

    public string name;
    public Sprite icon;
    public float cost;
    public float craftCost;
    
    [TextArea]
    public string displayText;
    
    public List<ItemUpgradeEffect> effects;

    public List<ScriptableObject> requiredItems;
}