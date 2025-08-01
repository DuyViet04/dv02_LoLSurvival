using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class EnemyDealingDamage : DealingDamage
{
    [SerializeField] private MainEnemyStats stats;

    private void FixedUpdate()
    {
        this.attackDamage = this.stats.attackData.baseDamage;
    }
    
    //Lấy AttackData từ stats
    public AttackData GetAttackData()
    {
        return this.stats.attackData;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadStats();
    }

    void LoadStats()
    {
        if (this.stats != null) return;
        this.stats = SOManager.Instance.GetEnemyStatsByType(this.transform.parent.name);
        Debug.LogWarning(this.transform.name + ": LoadStats", this.gameObject);
    }
}