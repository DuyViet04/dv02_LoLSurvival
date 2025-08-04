using UnityEngine;

public abstract class TakingDamage : MonoBehaviour
{
    protected float maxHp;
    protected float currentHp;
    protected float armor;
    protected float magicResistance;

    //Trừ hp khi nhận damage
    public virtual void TakeDamage(float damage)
    {
        this.currentHp -= damage;
        if (this.currentHp <= 0f)
        {
            this.currentHp = 0f;
        }

        this.OnDead();
    }

    //Tính toán tỉ lệ damage nhận vào

    public float GetAttackDamageMultiplier(float armorPenetration)
    {
        float newArmor = this.armor - armorPenetration;
        return 1 - newArmor / (100 + Mathf.Abs(newArmor));
    }

    public float GetAbilityPowerMultiplier(float magicPenetration)
    {
        float newMagicResist = this.magicResistance - magicPenetration;
        return 1 - newMagicResist / (100 + Mathf.Abs(newMagicResist));
    }

    //Hồi máu theo máu hồi
    protected virtual void RegenHealth(float value)
    {
        this.currentHp += value;
        if (this.currentHp >= this.maxHp)
        {
            this.currentHp = this.maxHp;
        }
    }

    //Hồi máu theo hút máu
    public virtual void LifeSteal(float value)
    {
        this.currentHp += value;
        if (this.currentHp >= this.maxHp)
        {
            this.currentHp = this.maxHp;
        }
    }

    //Hồi máu theo hút máu toàn phần
    public virtual void Omnivamp(float value)
    {
        this.currentHp += value;
        if (this.currentHp >= this.maxHp)
        {
            this.currentHp = this.maxHp;
        }
    }

    //Kiểm tra xem đã chết hay chưa
    private bool IsDead()
    {
        if (this.currentHp > 0f) return false;
        return true;
    }

    //Xử lý khi chết
    private void OnDead()
    {
        if (!IsDead()) return;
        this.Despawn();
    }

    protected abstract void Despawn();
}