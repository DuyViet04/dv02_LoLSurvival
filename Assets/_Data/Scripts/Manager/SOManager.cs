using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SOManager : MonoBehaviour
{
    private static SOManager instance;
    public static SOManager Instance => instance;

    [SerializeField] private List<MainEnemyStats> enemyStatsList;


    private void Awake()
    {
        if (instance != null) Debug.LogError("More than one instance of SOManager");
        instance = this;
    }

    void Reset()
    {
        this.LoadEnemyStatsList();
    }

    void LoadEnemyStatsList()
    {
        string[] guids = AssetDatabase.FindAssets("t:MainEnemyStats",
            new[] { "Assets/_Data/Scripts/Stat/Enemy/SO" });
        if (guids.Length > 0)
        {
            for (int i = 0; i < guids.Length; i++)
            {
                string path = AssetDatabase.GUIDToAssetPath(guids[i]);
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