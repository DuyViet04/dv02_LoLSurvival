using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTakingDamage : TakingDamage
{
    [SerializeField] private YasuoStats stats;
    [SerializeField] private Image hpImage;
    [SerializeField] private Animator playerAnimator;

    private void Start()
    {
        this.maxHp = this.stats.health;
        this.currentHp = this.maxHp;
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

        Debug.Log(currentHp);
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
            Debug.Log("Take Damage");
        }
    }
}