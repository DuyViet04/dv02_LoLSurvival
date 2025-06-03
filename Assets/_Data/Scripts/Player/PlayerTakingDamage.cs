using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerTakingDamage : TakingDamage
{
    [SerializeField] private YasuoStats yasuoStats;
    [SerializeField] private Image hpImage;
    [SerializeField] private TMP_Text hpText;
    [SerializeField] private TMP_Text hpRegenText;

    private void Start()
    {
        this.maxHp = this.yasuoStats.health;
        this.currentHp = this.maxHp;
    }

    private void FixedUpdate()
    {
        this.maxHp = this.yasuoStats.health;
        this.armor = this.yasuoStats.armor;
        float regenValue = this.yasuoStats.healthRegen * (1 + this.yasuoStats.healingPower / 100);
        this.RegenHealth(regenValue / (1 / Time.fixedDeltaTime));
        this.hpRegenText.text = $"+{regenValue:F1}/s";
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        if (this.currentHp <= 0f)
        {
            this.hpImage.fillAmount = 0f;
        }
        else
        {
            this.hpImage.fillAmount = this.currentHp / maxHp;
        }

        this.hpText.text = $"{this.currentHp:N0} / {this.maxHp}";
    }

    protected override void RegenHealth(float value)
    {
        base.RegenHealth(value);
        if (this.currentHp >= this.maxHp)
        {
            this.hpImage.fillAmount = 1f;
        }
        else
        {
            this.hpImage.fillAmount = this.currentHp / maxHp;
        }

        this.hpText.text = $"{this.currentHp:N0} / {this.maxHp}";
    }

    public override void LifeSteal(float value)
    {
        base.LifeSteal(value);
        if (this.currentHp >= this.maxHp)
        {
            this.hpImage.fillAmount = 1f;
        }
        else
        {
            this.hpImage.fillAmount = this.currentHp / maxHp;
        }

        this.hpText.text = $"{this.currentHp:N0} / {this.maxHp}";
    }

    public override void Omnivamp(float value)
    {
        base.Omnivamp(value);
        if (this.currentHp >= this.maxHp)
        {
            this.hpImage.fillAmount = 1f;
        }
        else
        {
            this.hpImage.fillAmount = this.currentHp / maxHp;
        }

        this.hpText.text = $"{this.currentHp:N0} / {this.maxHp}";
    }

    protected override void Despawn()
    {
        GameManager.Instance.CSCount = CSDisplay.Instance.CSCount;
        GameManager.Instance.MainStatsData = StatsDisplay.Instance.GetLastMainData();
        GameManager.Instance.SecondStatsData = StatsDisplay.Instance.GetLastSecondData();
        SceneManager.LoadScene("Gameover");
    }

    private void OnTriggerEnter(Collider other)
    {
        Transform parent = other.transform.parent;

        if (parent != null && parent.CompareTag("Enemy"))
        {
            AttackData attackData = parent.GetComponentInChildren<EnemyDealingDamage>().GetAttackData();
            parent.GetComponentInChildren<EnemyDealingDamage>().DealDamage(this.transform.parent, attackData);
        }
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadYasuoStats();
        this.LoadHPImage();
        this.LoadHPText();
        this.LoadHPRegenText();
    }

    void LoadYasuoStats()
    {
        if (this.yasuoStats != null) return;
        string[] guids = AssetDatabase.FindAssets("t:YasuoStats", new[] { "Assets/_Data/Scripts/Stat/Character/SO" });
        string path = AssetDatabase.GUIDToAssetPath(guids[0]);
        this.yasuoStats = AssetDatabase.LoadAssetAtPath<YasuoStats>(path);
        Debug.LogWarning(this.transform.name + ": LoadYasuoStats", this.gameObject);
    }

    void LoadHPImage()
    {
        if (this.hpImage != null) return;
        this.hpImage = GameObject.Find("HP").GetComponent<Image>();
        Debug.LogWarning(this.transform.name + ": LoadHPImage", this.gameObject);
    }

    void LoadHPText()
    {
        if (this.hpText != null) return;
        this.hpText = GameObject.Find("HPText").GetComponent<TMP_Text>();
        Debug.LogWarning(this.transform.name + ": LoadHPText", this.gameObject);
    }

    void LoadHPRegenText()
    {
        if (this.hpRegenText != null) return;
        this.hpRegenText = GameObject.Find("HPRegenText").GetComponent<TMP_Text>();
        Debug.LogWarning(this.transform.name + ": LoadHPRegenText", this.gameObject);
    }
}