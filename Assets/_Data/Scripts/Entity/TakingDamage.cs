using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakingDamage : MonoBehaviour
{
    protected float maxHp = 2f;
    protected float currentHp;

    public virtual void TakeDamage(float damage)
    {
        this.currentHp -= damage;
        if (this.currentHp <= 0f)
        {
            this.currentHp = 0f;
        }
    }
}