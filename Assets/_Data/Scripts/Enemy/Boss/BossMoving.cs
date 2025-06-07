using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMoving : MovingToTarget
{
    [SerializeField] private Animator animator;
    [SerializeField] private float moveSpeed = 3f;


    private void Update()
    {
        float moveSpd;
        float dis = this.GetDistanceToTarget();
        if (dis > 5f)
        {
            moveSpd = this.moveSpeed;
        }
        else
        {
            moveSpd = 0;
        }

        this.MoveToTarget(moveSpd);
        this.animator.SetFloat("isMove", moveSpd);
    }

    float GetDistanceToTarget()
    {
        return Vector3.Distance(this.transform.parent.position, this.target.transform.position);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTarget();
        this.LoadAnimator();
    }

    void LoadTarget()
    {
        if (this.target != null) return;
        this.target = GameObject.FindGameObjectWithTag("Player");
        Debug.LogWarning(this.transform.name + ": LoadTarget", this.gameObject);
    }

    void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = this.transform.parent.GetComponentInChildren<Animator>();
        Debug.LogWarning(this.transform.name + ": LoadAnimator", this.gameObject);
    }
}