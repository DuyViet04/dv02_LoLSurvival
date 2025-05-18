using UnityEngine;

public class EnemyTakingDamage : TakingDamage
{
    [SerializeField] private MeleeEnemyStats stats;

    private void Start()
    {
        this.maxHp = this.stats.health;
        this.currentHp = this.maxHp;
    }

    private void FixedUpdate()
    {
        this.armor = this.stats.armor;
    }

    protected override void Despawn()
    {
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