using System;
using System.Collections.Generic;
using UnityEditor;
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
        string[] strings = AssetDatabase.FindAssets("t:ItemData", new string[] { "Assets/_Data/Scripts/Item" });
        foreach (string str in strings)
        {
            string path = AssetDatabase.GUIDToAssetPath(str);
            ItemData itemData = AssetDatabase.LoadAssetAtPath<ItemData>(path);
            items.Add(itemData);
        }
    }
}