using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DealingDamage : MonoBehaviour
{
    protected float damage = 1f;

    public virtual void DealDamage(Transform target)
    {
        TakingDamage takingDamage = target.GetComponentInChildren<TakingDamage>();
        if (takingDamage == null) return;
        this.DealDamage(takingDamage);
    }

    public virtual void DealDamage(TakingDamage takingDamage)
    {
        takingDamage.TakeDamage(this.damage);
    }
}