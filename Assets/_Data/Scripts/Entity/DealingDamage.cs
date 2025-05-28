using UnityEngine;

public abstract class DealingDamage : VyesBehaviour
{
    protected float attackDamage;
    protected float abilityPower;
    protected float damageDealt;
    protected float criticalChance;
    protected float criticalDamage;
    protected float armorPenetration;
    protected float magicPenetration;
    protected float lifeSteal;
    protected float omnivamp;
    protected float healingPower;

    //Gây damage cho target có "TakingDamage"
    public virtual void DealDamage(Transform target, AttackData attackData)
    {
        TakingDamage takingDamage = target.GetComponentInChildren<TakingDamage>();
        if (takingDamage == null) return;
        this.DealDamage(takingDamage, attackData);
    }

    protected virtual void DealDamage(TakingDamage takingDamage, AttackData attackData)
    {
        this.GetDamageDealt(takingDamage, attackData);
        takingDamage.TakeDamage(this.damageDealt);
    }

    //Hồi máu cho target có "TakingDamage"
    protected void Heal(Transform target)
    {
        TakingDamage takingDamage = target.GetComponentInChildren<TakingDamage>();
        if (takingDamage == null) return;
        this.Heal(takingDamage);
    }

    protected virtual void Heal(TakingDamage takingDamage)
    {
        takingDamage.LifeSteal(this.damageDealt * (this.lifeSteal / 100) * (1 + this.healingPower / 100));
        takingDamage.Omnivamp(this.damageDealt * (this.omnivamp / 300) * (1 + this.healingPower / 100));
    }

    //Tính lượng damage gây ra
    protected virtual float GetDamageDealt(TakingDamage takingDamage, AttackData attackData)
    {
        switch (attackData.damageType)
        {
            case DamageType.PhysicDamage:
                float atkDmgMulti = takingDamage.GetAttackDamageMultiplier(this.armorPenetration);
                if (attackData.isCritical)
                {
                    float roll = Random.Range(0f, 100f);
                    if (roll > this.criticalChance)
                    {
                        this.damageDealt = attackData.GetDamage(this.attackDamage, this.abilityPower) * atkDmgMulti;
                    }
                    else
                    {
                        this.damageDealt = attackData.GetDamage(this.attackDamage, this.abilityPower) *
                                           (this.criticalDamage / 100) * atkDmgMulti;
                    }
                }

                Debug.Log(
                    $"{attackData.attackType} - {attackData.damageType} - {this.damageDealt} - {attackData.isCritical}");
                break;
            case DamageType.MagicDamage:
                float magicDmgMulti = takingDamage.GetAbilityPowerMultiplier(this.magicPenetration);
                this.damageDealt = attackData.GetDamage(this.attackDamage, this.abilityPower) * magicDmgMulti;
                Debug.Log(
                    $"{attackData.attackType} - {attackData.damageType} - {this.damageDealt} - {attackData.isCritical}");

                break;
            case DamageType.TrueDamage:
                this.damageDealt = attackData.GetDamage(this.attackDamage, this.abilityPower);
                Debug.Log(
                    $"{attackData.attackType} - {attackData.damageType} - {this.damageDealt} - {attackData.isCritical}");

                break;
        }

        return this.damageDealt;
    }
}