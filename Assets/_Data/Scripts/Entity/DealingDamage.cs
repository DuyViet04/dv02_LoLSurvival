using UnityEngine;

public abstract class DealingDamage : MonoBehaviour
{
    protected float damage = 1f;
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
        takingDamage.TakeDamage(this.damage, this.armorPenetration);
        this.Heal(this.transform.root);
    }

    protected void Heal(Transform target)
    {
        TakingDamage takingDamage = target.GetComponentInChildren<TakingDamage>();
        if (takingDamage == null) return;
        this.Heal(takingDamage, this.damage, this.lifeSteal, this.omnivamp, this.healingPower);
    }

    protected void Heal(TakingDamage takingDamage, float damage, float lifeSteal, float omnivamp, float healingPower)
    {
        takingDamage.LifeSteal(damage * (lifeSteal / 100) * (1 + healingPower / 100));
        takingDamage.Omnivamp(damage * (omnivamp / 300) * (1 + healingPower / 100));
    }
}