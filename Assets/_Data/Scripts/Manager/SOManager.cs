using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SOManager : MonoBehaviour
{
    [SerializeField] private List<MainEnemyStats> enemyStatsList;

    void Reset()
    {
        this.enemyStatsList.Clear();
        this.LoadEnemyStatsList();
    }

    void LoadEnemyStatsList()
    {
        string[] guids = AssetDatabase.FindAssets("t:MainEnemyStats",
            new[] { "Assets/_Data/Scripts/Stat/Enemy/SO" });
        if (guids.Length > 0)
        {
            foreach (string item in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(item);
                MainEnemyStats stats = AssetDatabase.LoadAssetAtPath<MainEnemyStats>(path);
                this.enemyStatsList.Add(stats);
            }
        }
    }

    public MainEnemyStats GetStatsByType(string type)
    {
        foreach (MainEnemyStats item in this.enemyStatsList)
        {
            string typeName = item.type.ToString();
            if (typeName == type) return item;
        }

        return null;
    }

    public List<MainEnemyStats> GetEnemyStatsList()
    {
        return this.enemyStatsList;
    }
}