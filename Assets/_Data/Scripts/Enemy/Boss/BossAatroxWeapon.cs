using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BossAatroxWeapon : DealingDamage
{
    [SerializeField] private MainBossStats bossStats;
    [SerializeField] private BossAatroxSkill bossAatroxSkill;
    private BossAttacking bossAttacking;
    private AttackData attackData;


    protected override void Awake()
    {
        base.Awake();
        this.bossAttacking = this.transform.root.GetComponentInChildren<BossAttacking>();
        this.attackData = new AttackData();
    }

    private void Update()
    {
        this.attackDamage = this.bossStats.attackDamage;
        this.abilityPower = this.bossStats.abilityPower;
        this.armorPenetration = this.bossStats.armorPenetration;
        this.magicPenetration = this.bossStats.magicPenetration;
        this.criticalChance = this.bossStats.criticalChance;
        this.criticalDamage = this.bossStats.criticalDamage;
        this.lifeSteal = this.bossStats.lifeSteal;
        this.omnivamp = this.bossStats.omnivamp;
        this.healingPower = this.bossStats.healingPower;
    }

    private void OnTriggerEnter(Collider other)
    {
        Transform parent = other.transform.parent;
        if (parent != null && parent.CompareTag("Player"))
        {
            this.GetAttackData();
            this.DealDamage(parent.GetComponentInChildren<PlayerTakingDamage>(), this.attackData);
        }
    }

    void GetAttackData()
    {
        switch (this.bossAttacking.CurrentAnim)
        {
            case "Skill1":
                this.attackData = this.bossAatroxSkill.bossAatroxSkillData[0];
                break;
            case "Skill1_1":
                this.attackData = this.bossAatroxSkill.bossAatroxSkillData[1];
                break;
            case "Skill1_2":
                this.attackData = this.bossAatroxSkill.bossAatroxSkillData[2];
                break;
            default:
                this.attackData = new AttackData();
                break;
        }
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBossStats();
        this.LoadBossAatroxSkill();
    }

    void LoadBossStats()
    {
        if (this.bossStats != null) return;
        this.bossStats = SOManager.Instance.GetBossStatsByType(this.transform.root.name);
        Debug.LogWarning(this.transform.name + ": LoadBossStats", this.gameObject);
    }

    void LoadBossAatroxSkill()
    {
        if (this.bossAatroxSkill != null) return;
        this.bossAatroxSkill = Resources.Load<BossAatroxSkill>("Skill/Boss/BossAatroxSkill");
        Debug.LogWarning(this.transform.name + ": LoadBossAatroxSkill", this.gameObject);
    }
}