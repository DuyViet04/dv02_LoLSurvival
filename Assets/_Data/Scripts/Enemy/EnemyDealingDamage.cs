using System;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class EnemyDealingDamage : DealingDamage
{
    [SerializeField] private MainEnemyStats stats;
    [SerializeField] private SOManager soManager;

    private void FixedUpdate()
    {
        this.damage = this.stats.damage;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadStats();
    }

    void LoadStats()
    {
        this.LoadSoManager();

        if (this.stats != null) return;
        this.stats = this.soManager.GetStatsByType(this.transform.parent.name);
        Debug.LogWarning(this.transform.name + ": LoadStats", this.gameObject);
    }

    void LoadSoManager()
    {
        if (this.soManager != null) return;
        this.soManager = GameObject.FindObjectOfType<SOManager>();
        Debug.LogWarning(this.transform.name + ": LoadSOManager", this.gameObject);
    }
}