using UnityEngine;

public abstract class DealingDamage : VyesBehaviour
{
    protected float damage;
    protected float damageDealt;
    protected float armorPenetration;
    protected float lifeSteal;
    protected float omnivamp;
    protected float healingPower;

    public virtual void DealDamage(Transform target)
    {
        TakingDamage takingDamage = target.GetComponentInChildren<TakingDamage>();
        if (takingDamage == null) return;
        this.DealDamage(takingDamage);
    }

    protected virtual void DealDamage(TakingDamage takingDamage)
    {
        this.GetDamageDealt(takingDamage);
        takingDamage.TakeDamage(this.damageDealt);
    }

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

    protected virtual float GetDamageDealt(TakingDamage takingDamage)
    {
        float dmgMulti = takingDamage.GetDamageMultiplier(this.armorPenetration);
        this.damageDealt = this.damage * dmgMulti;
        return this.damageDealt;
    }
}