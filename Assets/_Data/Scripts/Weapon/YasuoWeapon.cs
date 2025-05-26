using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(CapsuleCollider))]
public class YasuoWeapon : DealingDamage
{
    [SerializeField] private YasuoStats yasuoStats;
    [SerializeField] private Transform player;

    private void FixedUpdate()
    {
        this.lifeSteal = this.yasuoStats.lifeSteal;
        this.omnivamp = this.yasuoStats.omnivamp;
        this.healingPower = this.yasuoStats.healingPower;
    }

    protected override void DealDamage(TakingDamage takingDamage)
    {
        base.DealDamage(takingDamage);
        takingDamage.TakeDamage(this.damageDealt);
        this.Heal(this.player.GetComponentInChildren<PlayerTakingDamage>());
    }

    protected override float GetDamageDealt(TakingDamage takingDamage)
    {
        float dmgMulti = takingDamage.GetDamageMultiplier(this.yasuoStats.armorPenetration);
        float roll = Random.Range(0f, 100f);
        if (roll > this.yasuoStats.criticalChance)
        {
            this.damageDealt = this.yasuoStats.attackDamage * dmgMulti;
        }
        else
        {
            this.damageDealt = this.yasuoStats.attackDamage * this.yasuoStats.criticalDamage / 100 * dmgMulti;
        }

        return this.damageDealt;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadYasuoStats();
        this.LoadPlayer();
    }

    void LoadYasuoStats()
    {
        if (this.yasuoStats != null) return;
        string[] guids = AssetDatabase.FindAssets("t:YasuoStats", new[] { "Assets/_Data/Scripts/Stat/Character/SO" });
        string assetPath = AssetDatabase.GUIDToAssetPath(guids[0]);
        this.yasuoStats = AssetDatabase.LoadAssetAtPath<YasuoStats>(assetPath);
        Debug.LogWarning(this.transform.name + ": LoadYasuoStats", this.gameObject);
    }

    void LoadPlayer()
    {
        if (this.player != null) return;
        this.player = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.LogWarning(this.transform.name + ": LoadPlayer", this.gameObject);
    }
}