using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class YasuoWeapon : DealingDamage
{
    [SerializeField] private YasuoStats yasuoStats;
    [SerializeField] private YasuoSkill yasuoSkill;
    [SerializeField] private Transform player;

    public override void DealDamage(TakingDamage takingDamage, AttackData attackData)
    {
        this.attackDamage = this.yasuoStats.attackDamage;
        this.abilityPower = this.yasuoStats.abilityPower;
        this.armorPenetration = this.yasuoStats.armorPenetration;
        this.magicPenetration = this.yasuoStats.magicPenetration;
        this.criticalChance = this.yasuoStats.criticalChance;
        this.criticalDamage = this.yasuoStats.criticalDamage;
        this.lifeSteal = this.yasuoStats.lifeSteal;
        this.omnivamp = this.yasuoStats.omnivamp;
        this.healingPower = this.yasuoStats.healingPower;
        
        attackData = this.GetAttackData();
        this.damageDealt = this.GetDamageDealt(takingDamage, attackData); // Tính toán damage gây ra
        takingDamage.TakeDamage(this.damageDealt);
        this.Heal(this.player.GetComponentInChildren<PlayerTakingDamage>()); // Hồi máu cho người chơi
    }

    // Lấy AttackData từ YasuoSkill dựa trên chỉ số kỹ năng cuối cùng
    public AttackData GetAttackData()
    {
        return this.yasuoSkill.yasuoSkillData[this.yasuoSkill.lastSkillIndex];
    }
}