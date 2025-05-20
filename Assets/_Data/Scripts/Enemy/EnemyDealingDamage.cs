using System;
using UnityEngine;

public class EnemyDealingDamage : DealingDamage
{
    [SerializeField] private MainEnemyStats stats;
    [SerializeField] private SOManager soManager;

    private void Awake()
    {
        this.stats = this.soManager.GetStatsByType(this.transform.parent.name);
    }

    private void FixedUpdate()
    {
        this.damage = this.stats.damage;
    }
}