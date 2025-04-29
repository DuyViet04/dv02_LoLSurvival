using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDealingDamage : MonoBehaviour
{
    [SerializeField] private float damage = 7f;

    public void DealDamage(Transform target)
    {
        PlayerTakingDamage playerTakingDamage = target.GetComponentInChildren<PlayerTakingDamage>();
        if (playerTakingDamage == null) return;
        this.DealDamage(playerTakingDamage);
    }

    public void DealDamage(PlayerTakingDamage playerTakingDamage)
    {
        playerTakingDamage.TakeDamage(damage);
    }
}