using System;
using Base.Systems.Stat;
using UnityEngine;

namespace _Data.Refactor.Models.SOs.Upgrades.Data
{
    [Serializable]
    public class UpgradeData
    {
        public Sprite icon;
        public StatType type;
        public string name;
        public float value;
        public StatModifier statModifier;
    }
}