using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private YasuoStats yasuoStats;
    [SerializeField] private RarityTable rarityTable;

    void Start()
    {
        this.yasuoStats.ResetStats();
        this.rarityTable.ResetData();
    }
}