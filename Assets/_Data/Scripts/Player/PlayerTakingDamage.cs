using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTakingDamage : TakingDamage
{
    [SerializeField] private YasuoStats yasuoStats;
    [SerializeField] private Image hpImage;
    [SerializeField] private TMP_Text hpText;
    [SerializeField] private TMP_Text hpRegenText;

    private void Start()
    {
        this.maxHp = this.yasuoStats.health;
        this.currentHp = this.maxHp;
    }

    private void FixedUpdate()
    {
        this.maxHp = this.yasuoStats.health;
        this.armor = this.yasuoStats.armor;
        float regenValue = this.yasuoStats.healthRegen * (1 + this.yasuoStats.healingPower / 100);
        this.RegenHealth(regenValue / (1 / Time.fixedDeltaTime));
        this.hpRegenText.text = $"+{regenValue:F1}/s";
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        if (this.currentHp <= 0f)
        {
            this.hpImage.fillAmount = 0f;
        }
        else
        {
            this.hpImage.fillAmount = this.currentHp / maxHp;
        }

        this.hpText.text = $"{this.currentHp:N0} / {this.maxHp}";
    }

    protected override void RegenHealth(float value)
    {
        base.RegenHealth(value);
        if (this.currentHp >= this.maxHp)
        {
            this.hpImage.fillAmount = 1f;
        }
        else
        {
            this.hpImage.fillAmount = this.currentHp / maxHp;
        }

        this.hpText.text = $"{this.currentHp:N0} / {this.maxHp}";
    }

    public override void LifeSteal(float value)
    {
        base.LifeSteal(value);
        if (this.currentHp >= this.maxHp)
        {
            this.hpImage.fillAmount = 1f;
        }
        else
        {
            this.hpImage.fillAmount = this.currentHp / maxHp;
        }

        this.hpText.text = $"{this.currentHp:N0} / {this.maxHp}";
    }

    public override void Omnivamp(float value)
    {
        base.Omnivamp(value);
        if (this.currentHp >= this.maxHp)
        {
            this.hpImage.fillAmount = 1f;
        }
        else
        {
            this.hpImage.fillAmount = this.currentHp / maxHp;
        }

        this.hpText.text = $"{this.currentHp:N0} / {this.maxHp}";
    }

    protected override void Despawn()
    {
        //
    }

    private void OnTriggerEnter(Collider other)
    {
        Transform parent = other.transform.parent;

        if (parent != null && parent.CompareTag("Enemy"))
        {
            parent.GetComponentInChildren<EnemyDealingDamage>().DealDamage(this.transform);
        }
    }
}