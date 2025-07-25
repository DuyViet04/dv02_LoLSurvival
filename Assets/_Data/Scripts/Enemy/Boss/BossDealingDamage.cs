using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class BossDealingDamage : DealingDamage
{
    [SerializeField] private MainBossStats bossStats;
    private AttackData attackData;

    protected override void Awake()
    {
        base.Awake();
        
        // Tạo attackData cho va chạm
        this.attackData = new AttackData()
        {
            attackType = AttackType.NormalAttack,
            damageType = DamageType.PhysicDamage,
            baseDamage = this.bossStats.attackDamage,
            bonusAP = 0,
            bonusAD = 0,
            cooldown = 0,
            isCritical = false
        };
    }

    
    // Xử lý va chạm với Player
    private void OnTriggerEnter(Collider other)
    {
        Transform parent = other.transform.parent;
        if (parent != null && parent.CompareTag("Player"))
        {
            this.DealDamage(other.transform, this.attackData);
        }
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBossStats();
    }

    void LoadBossStats()
    {
        if (this.bossStats != null) return;
        this.bossStats = SOManager.Instance.GetBossStatsByType(this.transform.parent.name);
        Debug.LogWarning(this.transform.name + ": LoadBossStats", this.gameObject);
    }
}