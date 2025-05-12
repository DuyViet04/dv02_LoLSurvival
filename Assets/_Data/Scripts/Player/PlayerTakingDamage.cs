using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTakingDamage : TakingDamage
{
    [SerializeField] private YasuoStats stats;
    [SerializeField] private Image hpImage;
    [SerializeField] private TMP_Text hpText;
    [SerializeField] private TMP_Text hpRegenText;
    [SerializeField] private Animator playerAnimator;

    private void Start()
    {
        this.maxHp = this.stats.health;
        this.currentHp = this.maxHp;
    }

    private void FixedUpdate()
    {
        this.maxHp = this.stats.health;
        this.armor = this.stats.armor;
        float regenValue = this.stats.healthRegen * (1 + this.stats.healingPower / 100);
        this.RegenHealth(regenValue / (1 / Time.fixedDeltaTime));
        this.hpRegenText.text = $"+{regenValue:F1}/s";
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        this.playerAnimator.SetTrigger("isTakeDamage");
        if (this.currentHp <= 0f)
        {
            this.hpImage.fillAmount = 0f;
        }
        else
        {
            this.hpImage.fillAmount = this.currentHp / maxHp;
        }

        this.hpText.text = $"{this.currentHp:F1}/{this.maxHp}";
    }

    public override void RegenHealth(float value)
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

        this.hpText.text = $"{this.currentHp:F1}/{this.maxHp}";
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

        this.hpText.text = $"{this.currentHp:F1}/{this.maxHp}";
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

        this.hpText.text = $"{this.currentHp:F1}/{this.maxHp}";
    }

    public override void Despawn()
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