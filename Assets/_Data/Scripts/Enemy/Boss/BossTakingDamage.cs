using _Data.Refactor.Enums;
using _Data.Scripts.Manager;
using Base.Systems.Combat;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CapsuleCollider))]
public class BossTakingDamage : TakingDamage
{
    [SerializeField] private MainBossStats bossStats;
    [SerializeField] private Image hpImage;
    [SerializeField] private GameObject bossHPBarCanvas;


    private void Awake()
    {
        this.bossHPBarCanvas.SetActive(true); // Bật canvas hiển thị thanh máu của boss
        this.maxHp = this.bossStats.health;
        this.currentHp = this.maxHp;
    }

    private void Update()
    {
        this.maxHp = this.bossStats.health;
        this.armor = this.bossStats.armor;
        this.magicResistance = this.bossStats.magicResistance;
    }

    // Xử lý khi nhận damage
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        if (this.currentHp <= 0f)
        {
            this.currentHp = 0f;
            this.hpImage.fillAmount = 0f; // Cập nhật thanh máu về 0 khi chết
        }
        else
        {
            this.hpImage.fillAmount = this.currentHp / this.maxHp; // Cập nhật thanh máu
        }
    }

    // Xử lý va chạm với vũ khí
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(nameof(TagEnum.Weapon)))
        {
            // AttackData attackData = other.GetComponent<YasuoWeapon>().GetAttackData();
            // other.GetComponent<YasuoWeapon>().DealDamage(this.transform, attackData);
        }
    }

    // Xử lý khi chết
    protected override void Despawn()
    {
        GameManager.Ins.CSCount = CSDisplay.Ins.CSCount; // Lưu số lính đã tiêu diệt
        GameManager.Ins.MainStatsData =
            StatsDisplay.Ins.GetLastMainData(); // Lưu lại stats cuối cùng của người chơi
        GameManager.Ins.SecondStatsData =
            StatsDisplay.Ins.GetLastSecondData(); // Lưu lại stats cuối cùng của người chơi
        GameManager.Ins.ItemSprites = ShopManager.Ins.GetLastItem(); // Lưu lại item cuối cùng của người chơi
        SceneLevelManager.Ins.GoToScene(nameof(ScenesEnum.GameVictory)); // Chuyển đến màn hình chiến thắng
    }
}