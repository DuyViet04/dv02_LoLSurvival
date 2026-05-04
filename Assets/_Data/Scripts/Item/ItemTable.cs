using System.Collections.Generic;
using _Data.Refactor.Models.SOs.Items;
using _Data.Refactor.Models.SOs.Items.Data;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemTable", menuName = "Item/ItemTable")]
public class ItemTable : ScriptableObject
{
    public List<ItemSo> items;

    private void Awake()
    {
        this.items.Clear();
        this.LoadData();
    }

    void Reset()
    {
        this.items.Clear();
        this.LoadData();
    }

    void LoadData()
    {
        ItemSo[] itemList = Resources.LoadAll<ItemSo>("Item");
        foreach (ItemSo item in itemList)
        {
            this.items.Add(item);
        }
    }
}