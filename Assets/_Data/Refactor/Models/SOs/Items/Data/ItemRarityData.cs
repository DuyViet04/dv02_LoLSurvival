using System;
using UnityEngine;

namespace _Data.Refactor.Models.SOs.Items.Data
{
    [Serializable]
    public class ItemRarityData
    {
        public ItemRarityType type;
        [Range(0f, 1f)] public float chance;
    }
}
