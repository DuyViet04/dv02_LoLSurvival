using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "NewItem", menuName = "Item/NewItem")]
public class ItemData : ScriptableObject
{
    public ItemType type;
    public ItemRarityType rarity;

    public string itemName;
    public Sprite icon;
    public float cost;
    public float craftCost;
    
    [TextArea]
    public string displayText;
    
    public List<ItemUpgradeEffect> effects;

    public List<ScriptableObject> requiredItems;
}