using UnityEngine;

public abstract class TakingDamage : MonoBehaviour
{
    protected float maxHp = 2f;
    protected float currentHp;
    protected float armor;

    public virtual void TakeDamage(float damage, float armorPenetration)
    {
        this.currentHp -= damage * this.GetDamageMultiplier(armorPenetration);
        if (this.currentHp <= 0f)
        {
            this.currentHp = 0f;
        }

        OnDead();
    }

    private float GetDamageMultiplier(float armorPenetration)
    {
        float newArmor = this.armor - armorPenetration;
        return 1 - newArmor / (100 + Mathf.Abs(newArmor));
    }

    protected virtual void RegenHealth(float value)
    {
        this.currentHp += value;
        if (this.currentHp >= this.maxHp)
        {
            this.currentHp = this.maxHp;
        }
    }

    public virtual void LifeSteal(float value)
    {
        this.currentHp += value;
        if (this.currentHp >= this.maxHp)
        {
            this.currentHp = this.maxHp;
        }
    }

    public virtual void Omnivamp(float value)
    {
        this.currentHp += value;
        if (this.currentHp >= this.maxHp)
        {
            this.currentHp = this.maxHp;
        }
    }

    private bool IsDead()
    {
        if (this.currentHp > 0f) return false;
        return true;
    }

    private void OnDead()
    {
        if (!IsDead()) return;
        this.Despawn();
    }

    protected abstract void Despawn();
}