using System;
using UnityEngine;

public class EnemyTakingDamage : TakingDamage
{
    [SerializeField] private EnemyScaleStats scaleStats;
    [SerializeField] private GoldDisplay goldDisplay;
    private MeleeEnemyStats meleeEnemyStats;

    private void Start()
    {
        this.currentHp = this.maxHp;
    }

    private void FixedUpdate()
    {
        this.meleeEnemyStats = this.scaleStats.GetStats();
        this.maxHp = this.meleeEnemyStats.health;
    }

    protected override void Despawn()
    {
        this.goldDisplay.GetGoldFromKill(this.meleeEnemyStats.goldValue);
        this.CreateExp();

        this.ResetStats();
        Debug.Log($"{meleeEnemyStats.health} {meleeEnemyStats.damage} {meleeEnemyStats.expValue}");

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