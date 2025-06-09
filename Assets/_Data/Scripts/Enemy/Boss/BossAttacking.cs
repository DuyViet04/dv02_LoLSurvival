using System;
using UnityEngine;
using UnityEngine.Serialization;

public class BossAttacking : VyesBehaviour
{
    [SerializeField] private Animator animator;
    private float cooldownTime = 12f;
    private float cooldownTimer;
    private bool isCooldown = false;
    public bool IsCooldown => this.isCooldown;
    private bool isAttacking = false;
    public bool IsAttacking => this.isAttacking;

    private void Update()
    {
        AnimatorStateInfo stateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("Q1") || stateInfo.IsName("Q2") || stateInfo.IsName("Q3"))
        {
            this.isAttacking = true;
        }
        else
        {
            this.isAttacking = false;
        }

        if (this.isCooldown)
        {
            this.animator.ResetTrigger("IsAttack");
            this.cooldownTimer -= Time.deltaTime;
            if (this.cooldownTimer <= 0)
            {
                this.cooldownTimer = 0;
                this.isCooldown = false;
            }
        }
        else
        {
            this.Attack();
        }

        Debug.Log(isAttacking);
    }

    void Attack()
    {
        if (this.isCooldown) return;
        this.animator.SetTrigger("IsAttack");
        this.isCooldown = true;
        this.cooldownTimer = this.cooldownTime;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
    }

    void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = this.transform.parent.GetComponentInChildren<Animator>();
        Debug.LogWarning(this.transform.name + ": LoadAnimator", this.gameObject);
    }
}