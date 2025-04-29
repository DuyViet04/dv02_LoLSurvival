using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakingDamage : MonoBehaviour
{
    [SerializeField] private float maxHp = 100f;
    private float currentHp;

    private void Start()
    {
        this.currentHp = this.maxHp;
    }

    public void TakeDamage(float damage)
    {
        currentHp -= damage;
        if (currentHp <= 0f)
        {
            currentHp = 0f;
        }
        Debug.Log(currentHp);
    }

    private void OnTriggerEnter(Collider other)
    {
        Transform parent = other.transform.parent;

        if (parent != null && parent.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyDealingDamage>().DealDamage(this.transform);
            Debug.Log("Take Damage");
        }
    }
}