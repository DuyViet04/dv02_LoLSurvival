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
            case nameof(EnemyType.KrugL):
                EnemySpawner.Instance.Spawn(nameof(EnemyType.KrugM), this.transform.parent.position,
                    Quaternion.identity, 2);
                break;
            case nameof(EnemyType.KrugM):
                EnemySpawner.Instance.Spawn(nameof(EnemyType.KrugS), this.transform.parent.position,
                    Quaternion.identity, 2);
                break;
        }

        this.goldDisplay.GetGoldFromKill(this.stats.goldValue); //Cộng vàng cho người chơi
        AudioManager.Instance.PlaySFXClip(nameof(AudioNameEnum.GetGold));
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

    
    // Xử lý va chạm với vũ khí
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(nameof(TagEnum.Weapon)))
        {
            AttackData attackData = other.GetComponent<YasuoWeapon>().GetAttackData();
            other.GetComponent<YasuoWeapon>().DealDamage(this.transform, attackData);
        }
    }
}