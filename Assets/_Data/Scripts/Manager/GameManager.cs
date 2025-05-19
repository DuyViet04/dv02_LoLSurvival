using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private YasuoStats yasuoStats;

    private void Awake()
    {
        this.ResetStats();
    }

    void ResetStats()
    {
        this.yasuoStats.ResetStats();

        List<MainEnemyStats> list = SOManager.Instance.GetEnemyStatsList();
        foreach (MainEnemyStats item in list)
        {
            item.ResetStats();
        }
    }
}