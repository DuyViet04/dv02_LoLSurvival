using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemTable", menuName = "Item/ItemTable")]
public class ItemTable : ScriptableObject
{
    public List<ItemData> items;

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
        ItemData[] itemList = Resources.LoadAll<ItemData>("Item");
        foreach (ItemData item in itemList)
        {
            this.items.Add(item);
        }
    }
}