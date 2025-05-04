using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakingDamage : MonoBehaviour
{
    [SerializeField] protected float maxHp = 2f;
    protected float currentHp;

    private void Start()
    {
        this.currentHp = this.maxHp;
    }

    public virtual void TakeDamage(float damage)
    {
        this.currentHp -= damage;
        if (this.currentHp <= 0f)
        {
            this.currentHp = 0f;
        }
    }
}