using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacking : MonoBehaviour
{
    [SerializeField] private YasuoStats stats;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform model;
    private float attackTimer = 0f;

    private void Update()
    {
        this.attackTimer += Time.deltaTime;
        if (this.attackTimer < this.GetAttackDelay(this.stats.attackSpeed)) return;
        this.attackTimer = 0f;
        this.Attack();
    }

    void Attack()
    {
        this.animator.SetTrigger("isAttack");
        this.animator.speed = this.GetAnimationSpeed(this.stats.attackSpeed);
        Debug.Log("Attack");
    }

    float GetAttackDelay(float attackSpeed)
    {
        return 1 / attackSpeed;
    }

    float GetAnimationSpeed(float attackSpeed)
    {
        return 1 * attackSpeed;
    }
}