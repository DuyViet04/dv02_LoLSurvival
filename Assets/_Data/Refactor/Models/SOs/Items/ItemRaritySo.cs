using System.Collections.Generic;
using _Data.Refactor.Models.SOs.Items.Data;
using UnityEngine;

namespace _Data.Refactor.Models.SOs.Items
{
    [CreateAssetMenu(fileName = "ItemRaritySo", menuName = "SOs/Items/ItemRaritySo")]
    public class ItemRaritySo : ScriptableObject
    {
        public List<ItemRarityData> itemRarities;
    }
}