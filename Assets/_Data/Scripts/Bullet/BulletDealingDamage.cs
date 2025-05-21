using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletDealingDamage : DealingDamage
{

    public void SetAttackDamage(float damage)
    {
        this.damage = damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        Transform parent = other.transform.parent;
        if (parent != null && parent.CompareTag("Player"))
        {
            parent.GetComponentInChildren<PlayerTakingDamage>().TakeDamage(this.damage, this.armorPenetration);
            BulletSpawner.Instance.Despawn(this.transform.parent);
        }
    }
}