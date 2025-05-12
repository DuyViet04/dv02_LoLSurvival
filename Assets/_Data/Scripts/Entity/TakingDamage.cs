using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TakingDamage : MonoBehaviour
{
    protected float maxHp = 2f;
    protected float currentHp;
    protected float armor;

    public virtual void TakeDamage(float damage)
    {
        this.currentHp -= damage * this.GetDamageMultiplayer();
        if (this.currentHp <= 0f)
        {
            this.currentHp = 0f;
        }

        OnDead();
    }

    public virtual float GetDamageMultiplayer()
    {
        return 1 - this.armor / (100 + this.armor);
    }

    public virtual void RegenHealth(float value)
    {
        this.currentHp += value;
        if (this.currentHp >= maxHp)
        {
            this.currentHp = maxHp;
        }
    }

    public virtual void LifeSteal(float value)
    {
        this.currentHp += value;
        if (this.currentHp >= maxHp)
        {
            this.currentHp = maxHp;
        }
    }

    public virtual void Omnivamp(float value)
    {
        this.currentHp += value;
        if (this.currentHp >= maxHp)
        {
            this.currentHp = maxHp;
        }
    }

    public virtual bool IsDead()
    {
        if (this.currentHp > 0f) return false;
        return true;
    }

    public virtual void OnDead()
    {
        if (!IsDead()) return;
        this.Despawn();
    }

    public abstract void Despawn();
}