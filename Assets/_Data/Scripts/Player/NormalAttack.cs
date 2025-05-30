using System;
using UnityEditor;
using UnityEngine;

public class NormalAttack : VyesBehaviour
{
    [SerializeField] private YasuoStats yasuoStats;
    [SerializeField] private YasuoSkill yasuoSkill;
    [SerializeField] private Animator animator;
    private float cooldownTime;
    private float cooldownTimer;
    private bool isCooldown = true;

    private void Update()
    {
        this.cooldownTime =
            CooldownCalculator.GetCooldown(this.yasuoSkill.yasuoSkillData[0].cooldown, this.yasuoStats.haste);

        if (this.isCooldown && (!Input.GetMouseButtonDown(0) && !Input.GetMouseButtonDown(1)))
        {
            this.animator.SetInteger("currentSkill", 3);
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
    }

    void Attack()
    {
        if (this.isCooldown) return;
        this.yasuoSkill.lastSkillIndex = 0;
        this.animator.SetInteger("currentSkill", 0);
        this.isCooldown = true;
        this.cooldownTimer = this.cooldownTime;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadYasuoStats();
        this.LoadYasuoSkill();
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

    void LoadYasuoSkill()
    {
        if (this.yasuoSkill != null) return;
        string[] guids = AssetDatabase.FindAssets("t:YasuoSkill", new[] { "Assets/_Data/Scripts/Player/Attack/SO" });
        string path = AssetDatabase.GUIDToAssetPath(guids[0]);
        this.yasuoSkill = AssetDatabase.LoadAssetAtPath<YasuoSkill>(path);
        Debug.LogWarning(this.transform.name + ": LoadYasuoSkill", this.gameObject);
    }

    void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = this.transform.parent.GetComponentInChildren<Animator>();
        Debug.LogWarning(this.transform.name + ": LoadAnimator", this.gameObject);
    }
}