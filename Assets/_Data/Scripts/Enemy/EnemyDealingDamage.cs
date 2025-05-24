using System;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class EnemyDealingDamage : DealingDamage
{
    [SerializeField] private MainEnemyStats stats;
    [SerializeField] private SOManager soManager;
    [SerializeField] private CapsuleCollider capsuleCollider;

    private void FixedUpdate()
    {
        this.damage = this.stats.damage;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadStats();
        this.LoadCapsuleCollider();
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

    void LoadCapsuleCollider()
    {
        if (this.capsuleCollider != null) return;
        this.capsuleCollider = this.GetComponent<CapsuleCollider>();
        this.capsuleCollider.center = new Vector3(0, 0.5f, 0);
        this.capsuleCollider.radius = 0.5f;
        this.capsuleCollider.height = 1;
        Debug.LogWarning(this.transform.name + ": LoadCapsuleCollider", this.gameObject);
    }
}