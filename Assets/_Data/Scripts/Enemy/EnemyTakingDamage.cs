using System;
using UnityEngine;

public class EnemyTakingDamage : TakingDamage
{
    [SerializeField] private GoldDisplay goldDisplay;
    [SerializeField] private MeleeEnemyStats baseMeleeEnemyStats;
    private MeleeEnemyStats meleeEnemyStats;

    private void Awake()
    {
        this.meleeEnemyStats = Instantiate(this.baseMeleeEnemyStats);
    }

    private void Start()
    {
        this.maxHp = this.meleeEnemyStats.health;
        this.currentHp = this.maxHp;
    }

    private void FixedUpdate()
    {
        this.armor = this.meleeEnemyStats.armor;
    }

    protected override void Despawn()
    {
        this.goldDisplay.GetGoldFromKill(this.meleeEnemyStats.goldValue);
        this.CreateExp();
        this.ResetStats();
        EnemySpawner.Instance.Despawn(this.transform.parent);
    }

    void CreateExp()
    {
        Transform exp = ExpSpawner.Instance.Spawn("Exp", this.transform.parent.position, Quaternion.identity);
        exp.GetComponentInChildren<ExpBehaviour>().SetExpValue(this.meleeEnemyStats.expValue);
    }

    void ResetStats()
    {
        this.currentHp = this.meleeEnemyStats.health;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            other.GetComponent<YasuoWeapon>().DealDamage(this.transform);
        }
    }
}