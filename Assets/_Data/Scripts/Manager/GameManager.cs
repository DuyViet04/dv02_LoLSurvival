using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private YasuoStats yasuoStats;

    private void Awake()
    {
        this.yasuoStats.ResetStats();
    }
}
