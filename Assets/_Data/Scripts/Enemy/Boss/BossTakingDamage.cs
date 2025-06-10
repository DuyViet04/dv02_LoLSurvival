using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CapsuleCollider))]
public class BossTakingDamage : TakingDamage
{
    [SerializeField] private MainBossStats bossStats;
    [SerializeField] private Image hpImage;
    [SerializeField] private GameObject bossHPBarCanvas;


    protected override void Awake()
    {
        base.Awake();
        this.bossHPBarCanvas.SetActive(true);
        this.maxHp = this.bossStats.health;
        this.currentHp = this.maxHp;
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        if (this.currentHp <= 0f)
        {
            this.currentHp = 0f;
            this.hpImage.fillAmount = 0f;
        }
        else
        {
            this.hpImage.fillAmount = this.currentHp / this.maxHp;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            AttackData attackData = other.GetComponent<YasuoWeapon>().GetAttackData();
            other.GetComponent<YasuoWeapon>().DealDamage(this.transform, attackData);
        }
    }

    protected override void Despawn()
    {
        SceneLevelManager.Instance.GoToScene("GameVictory");
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBossHPBarCanvas();
        this.LoadHpImage();
        this.LoadBossStats();
    }

    void LoadHpImage()
    {
        if (this.hpImage != null) return;
        Transform bossHpBar = this.bossHPBarCanvas.transform.Find("HPBar");
        this.hpImage = bossHpBar.Find("HP").GetComponent<Image>();
        Debug.LogWarning(this.transform.name + ": LoadHpImage", this.gameObject);
    }

    void LoadBossStats()
    {
        if (this.bossStats != null) return;
        this.bossStats = SOManager.Instance.GetBossStatsByType(this.transform.parent.name);
        Debug.LogWarning(this.transform.name + ": LoadBossStats", this.gameObject);
    }

    void LoadBossHPBarCanvas()
    {
        if (this.bossHPBarCanvas != null) return;
        this.bossHPBarCanvas = GameObject.Find("BossHPBarCanvas");
        Debug.LogWarning(this.transform.name + ": LoadBossHPBarCanvas", this.gameObject);
    }
}