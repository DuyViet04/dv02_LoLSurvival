using System;
using UnityEditor;
using UnityEngine;

public class PlayerAttacking : VyesBehaviour
{
    [SerializeField] private YasuoStats yasuoStats;
    [SerializeField] private FindClosestEnemy findClosest;
    [SerializeField] private Animator animator;
    private float attackTimer = 0f;

    private void Update()
    {
        float dis = this.findClosest.GetDistanceToTarget();
        if (dis > 7)
        {
            this.animator.ResetTrigger("isAttack");
            return;
        }

        this.attackTimer += Time.deltaTime;
        if (this.attackTimer < this.GetAttackDelay(this.yasuoStats.attackSpeed)) return;
        this.attackTimer = 0f;
        this.Attack();
    }

    void Attack()
    {
        this.animator.SetTrigger("isAttack");
        this.animator.speed = this.GetAnimationSpeed(this.yasuoStats.attackSpeed);
    }

    float GetAttackDelay(float attackSpeed)
    {
        return 1 / attackSpeed;
    }

    float GetAnimationSpeed(float attackSpeed)
    {
        return 1 * attackSpeed;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadYasuoStats();
        this.LoadFindClosest();
        this.LoadAnimator();
    }

    void LoadYasuoStats()
    {
        if (this.yasuoStats != null) return;
        string[] guids = AssetDatabase.FindAssets("t:YasuoStats", new[] { "Assets/_Data/Scripts/Stat/Character/SO" });
        string path = AssetDatabase.GUIDToAssetPath(guids[0]);
        this.yasuoStats = AssetDatabase.LoadAssetAtPath<YasuoStats>(path);
        Debug.LogWarning(this.transform.name + ": LoadYasuoStats", this.gameObject);
    }

    void LoadFindClosest()
    {
        if (this.findClosest != null) return;
        this.findClosest = FindObjectOfType<FindClosestEnemy>();
        Debug.LogWarning(this.transform.name + ": LoadFindClosest", this.gameObject);
    }

    void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = this.transform.parent.GetComponentInChildren<Animator>();
        Debug.LogWarning(this.transform.name + ": LoadAnimator", this.gameObject);
    }
}