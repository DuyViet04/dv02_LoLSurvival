using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class EnemyTakingDamage : TakingDamage
{
    [SerializeField] private MainEnemyStats stats;
    [SerializeField] private GoldDisplay goldDisplay;

    private void Start()
    {
        this.maxHp = this.stats.health;
        this.currentHp = this.maxHp;
    }

    private void FixedUpdate()
    {
        this.maxHp = this.stats.health;
        this.armor = this.stats.armor;
        this.magicResistance = this.stats.magicResistance;
    }

    //Spawn quái nhỏ nếu là 2 loại dưới
    protected override void Despawn()
    {
        switch (this.transform.parent.name)
        {
            case "KrugL":
                EnemySpawner.Instance.Spawn(EnemyType.KrugM.ToString(), this.transform.parent.position,
                    Quaternion.identity, 2);
                break;
            case "KrugM":
                EnemySpawner.Instance.Spawn(EnemyType.KrugS.ToString(), this.transform.parent.position,
                    Quaternion.identity, 2);
                break;
        }

        this.goldDisplay.GetGoldFromKill(this.stats.goldValue);
        this.CreateExp();
        this.ResetStats();
        EnemySpawner.Instance.Despawn(this.transform.parent);
    }

    //Tạo exp khi chết
    void CreateExp()
    {
        Transform exp = ExpSpawner.Instance.Spawn("Exp", this.transform.parent.position, Quaternion.identity);
        exp.GetComponentInChildren<ExpBehaviour>().SetExpValue(this.stats.expValue);
    }

    //Khởi tạo tại currentHp bằng giá trị hp mới nhất
    void ResetStats()
    {
        this.currentHp = this.stats.health;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            AttackData attackData = other.GetComponent<YasuoWeapon>().GetAttackData();
            other.GetComponent<YasuoWeapon>().DealDamage(this.transform, attackData);
        }
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadStats();
        this.LoadGoldDisplay();
    }

    void LoadStats()
    {
        if (this.stats != null) return;
        this.stats = SOManager.Instance.GetEnemyStatsByType(this.transform.parent.name);
        Debug.LogWarning(this.transform.name + ": LoadStats", this.gameObject);
    }

    void LoadGoldDisplay()
    {
        if (this.goldDisplay != null) return;
        this.goldDisplay = FindObjectOfType<GoldDisplay>();
        Debug.LogWarning(this.transform.name + ": LoadGoldDisplay", this.gameObject);
    }
}