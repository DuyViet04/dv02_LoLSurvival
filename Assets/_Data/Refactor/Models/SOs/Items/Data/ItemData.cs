using System;
using System.Collections.Generic;
using Base.Systems.Stat;
using UnityEngine;

namespace _Data.Refactor.Models.SOs.Items.Data
{
    public enum ItemRarityType
    {
        Basic,
        Epic,
        Legendary
    }

    [Serializable]
    public class ItemStatModifier
    {
        public StatType type;
        public StatModifier modifier;
    }

    [Serializable]
    public class ItemData
    {
        public ItemRarityType rarity;
        public string itemName;
        public Sprite icon;
        public float cost;
        [TextArea] public string description;
        public List<ItemStatModifier> statModifiers;
    }
}