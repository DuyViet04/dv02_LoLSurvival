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
}