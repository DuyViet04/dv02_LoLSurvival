using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTakingDamage : MonoBehaviour
{
    [SerializeField] private Image hpImage;
    [SerializeField] private float maxHp = 100f;
    private float currentHp;

    private void Start()
    {
        this.currentHp = this.maxHp;
    }

    public void TakeDamage(float damage)
    {
        this.currentHp -= damage;
        if (this.currentHp <= 0f)
        {
            this.currentHp = 0f;
            this.hpImage.fillAmount = 0f;
        }
        else
        {
            this.hpImage.fillAmount = this.currentHp / maxHp;
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