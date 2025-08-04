using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class BossDealingDamage : DealingDamage
{
    [SerializeField] private MainBossStats bossStats;
    private AttackData attackData;

    private void Awake()
    {
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
        if (parent != null && parent.CompareTag(nameof(TagEnum.Player)))
        {
            this.DealDamage(other.transform, this.attackData);
        }
    }
}