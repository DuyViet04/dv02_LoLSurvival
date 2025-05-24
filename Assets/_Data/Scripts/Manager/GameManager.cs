using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float gameSpeed = 1;
    [SerializeField] private SOManager soManager;
    [SerializeField] private YasuoStats yasuoStats;

    private void Awake()
    {
        this.ResetStats();
    }

    private void Update()
    {
        Time.timeScale = this.gameSpeed;
    }

    void ResetStats()
    {
        this.yasuoStats.ResetStats();

        List<MainEnemyStats> list = this.soManager.GetEnemyStatsList();
        foreach (MainEnemyStats item in list)
        {
            item.ResetStats();
        }
    }
}