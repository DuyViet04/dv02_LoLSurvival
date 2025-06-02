using System;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(CapsuleCollider))]
public class YasuoWeapon : DealingDamage
{
    [SerializeField] private YasuoStats yasuoStats;
    [SerializeField] private YasuoSkill yasuoSkill;
    [SerializeField] private Transform player;
    [SerializeField] private CapsuleCollider capsule;

    public override void DealDamage(TakingDamage takingDamage, AttackData attackData)
    {
        this.attackDamage = this.yasuoStats.attackDamage;
        this.abilityPower = this.yasuoStats.abilityPower;
        this.armorPenetration = this.yasuoStats.armorPenetration;
        this.magicPenetration = this.yasuoStats.magicPenetration;
        this.criticalChance = this.yasuoStats.criticalChance;
        this.criticalDamage = this.yasuoStats.criticalDamage;
        this.lifeSteal = this.yasuoStats.lifeSteal;
        this.omnivamp = this.yasuoStats.omnivamp;
        this.healingPower = this.yasuoStats.healingPower;
        
        attackData = this.GetAttackData();
        this.damageDealt = this.GetDamageDealt(takingDamage, attackData);
        takingDamage.TakeDamage(this.damageDealt);
        this.Heal(this.player.GetComponentInChildren<PlayerTakingDamage>());
    }

    public AttackData GetAttackData()
    {
        return this.yasuoSkill.yasuoSkillData[this.yasuoSkill.lastSkillIndex];
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadYasuoStats();
        this.LoadYasuoSkill();
        this.LoadPlayer();
        this.LoadCapsuleCollider();
    }

    void LoadYasuoStats()
    {
        if (this.yasuoStats != null) return;
        string[] guids = AssetDatabase.FindAssets("t:YasuoStats", new[] { "Assets/_Data/Scripts/Stat/Character/SO" });
        string assetPath = AssetDatabase.GUIDToAssetPath(guids[0]);
        this.yasuoStats = AssetDatabase.LoadAssetAtPath<YasuoStats>(assetPath);
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

    void LoadPlayer()
    {
        if (this.player != null) return;
        this.player = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.LogWarning(this.transform.name + ": LoadPlayer", this.gameObject);
    }

    void LoadCapsuleCollider()
    {
        if (this.capsule != null) return;
        this.capsule = this.GetComponent<CapsuleCollider>();
        this.capsule.isTrigger = true;
        this.capsule.center = new Vector3(0, 75, 0);
        this.capsule.height = 110;
        this.capsule.radius = 5;
        Debug.LogWarning(this.transform.name + ": LoadCapsuleCollider", this.gameObject);
    }
}