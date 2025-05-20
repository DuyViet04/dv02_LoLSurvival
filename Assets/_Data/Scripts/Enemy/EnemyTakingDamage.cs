using System;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyTakingDamage : TakingDamage
{
    [SerializeField] private MainEnemyStats stats;
    [SerializeField] private GoldDisplay goldDisplay;
    [SerializeField] private SOManager soManager;

    private void Awake()
    {
        this.stats = this.soManager.GetStatsByType(this.transform.parent.name);
    }

    private void Start()
    {
        this.currentHp = this.maxHp;
    }

    private void FixedUpdate()
    {
        this.maxHp = this.stats.health;
    }

    protected override void Despawn()
    {
        this.goldDisplay.GetGoldFromKill(this.stats.goldValue);
        this.CreateExp();
        this.ResetStats();
        EnemySpawner.Instance.Despawn(this.transform.parent);
    }

    void CreateExp()
    {
        Transform exp = ExpSpawner.Instance.Spawn("Exp", this.transform.parent.position, Quaternion.identity);
        exp.GetComponentInChildren<ExpBehaviour>().SetExpValue(this.stats.expValue);
    }

    void ResetStats()
    {
        this.currentHp = this.stats.health;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            other.GetComponent<YasuoWeapon>().DealDamage(this.transform);
        }
    }
}