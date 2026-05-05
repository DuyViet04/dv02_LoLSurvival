using _Data.Refactor.Models.SOs.Items.Data;
using UnityEngine;

namespace _Data.Refactor.Models.SOs.Items
{
    [CreateAssetMenu(fileName = "ItemSo", menuName = "SOs/Items/ItemSo")]
    public class ItemSo : ScriptableObject
    {
        public ItemData itemData;
    }
}