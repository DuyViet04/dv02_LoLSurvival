using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LevelUp : VyesBehaviour
{
    [SerializeField] private RarityTable baseRarityTable;
    [SerializeField] private YasuoStats yasuoStats;
    [SerializeField] private GameObject levelUpPanel;
    [SerializeField] private Image expBar;
    [SerializeField] private TMP_Text levelText;
    private RarityTable rarityTable;
    private float currentLv = 1;
    private float maxExp;
    private float currentExp;

    protected override void Awake()
    {
        base.Awake();
        this.rarityTable = Instantiate(this.baseRarityTable);
    }

    private void Start()
    {
        this.maxExp = 180 + 100 * Mathf.Pow(this.currentLv - 1, 2);
        this.currentExp = 0;
        this.expBar.fillAmount = this.currentExp / this.maxExp;
        this.levelText.SetText(this.currentLv.ToString());
    }

    public void IncreaseExp(float expValue)
    {
        this.currentExp += expValue * (1 + this.yasuoStats.expMultiplier / 100);
        this.expBar.fillAmount = this.currentExp / this.maxExp;

        if (this.currentExp >= this.maxExp)
        {
            this.IncreaseLevel();
        }
    }

    void IncreaseLevel()
    {
        this.IncreaseRarity(this.rarityTable);

        this.levelUpPanel.SetActive(true);
        Time.timeScale = 0;
        LevelUpDisplay.Instance.ShowUpgradeChoices();

        //Tính toán kinh nghiệm cho level tiếp theo
        this.currentLv++;
        this.maxExp = 180 + 100 * Mathf.Pow(this.currentLv - 1, 2);
        this.currentExp = 0;
        this.expBar.fillAmount = this.currentExp / this.maxExp;
        this.levelText.SetText(this.currentLv.ToString());
    }

    public float GetCurrentLevel()
    {
        return this.currentLv;
    }

    // Xử lý tăng tỉ lệ theo cấp
    void IncreaseRarity(RarityTable table)
    {
        float progress = (float)1 / 49;

        if (this.currentLv > 50) return;
        table.rarities[0].chance -= progress * 10 / 15;
        table.rarities[1].chance += progress * 4 / 15;
        table.rarities[2].chance += progress * 3 / 15;
        table.rarities[3].chance += progress * 2 / 15;
        table.rarities[4].chance += progress * 1 / 15;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadYasuoStats();
        this.LoadLevelUpPanel();
        this.LoadExpBar();
        this.LoadLevelText();
        this.LoadRarityTable();
    }

    void LoadRarityTable()
    {
        if (this.baseRarityTable != null) return;
        string[] guids = AssetDatabase.FindAssets("t:RarityTable", new[] { "Assets/_Data/Scripts/Stat" });
        string path = AssetDatabase.GUIDToAssetPath(guids[0]);
        this.baseRarityTable = AssetDatabase.LoadAssetAtPath<RarityTable>(path);
        Debug.LogWarning(this.transform.name + ": LoadRarityTable", this.gameObject);
    }

    void LoadYasuoStats()
    {
        if (this.yasuoStats != null) return;
        string[] guids = AssetDatabase.FindAssets("t:YasuoStats", new[] { "Assets/_Data/Scripts/Stat/Character/SO" });
        string path = AssetDatabase.GUIDToAssetPath(guids[0]);
        this.yasuoStats = AssetDatabase.LoadAssetAtPath<YasuoStats>(path);
        Debug.LogWarning(this.transform.name + ": LoadYasuoStats", this.gameObject);
    }

    void LoadLevelUpPanel()
    {
        if (this.levelUpPanel != null) return;
        this.levelUpPanel = GameObject.Find("LevelUpPanel");
        Debug.LogWarning(this.transform.name + ": LoadLevelUpPanel", this.gameObject);
    }

    void LoadExpBar()
    {
        if (this.expBar != null) return;
        this.expBar = GameObject.Find("ExpBar").GetComponent<Image>();
        Debug.LogWarning(this.transform.name + ": LoadExpBar", this.gameObject);
    }

    void LoadLevelText()
    {
        if (this.levelText != null) return;
        this.levelText = GameObject.Find("LevelText").GetComponent<TMP_Text>();
        Debug.LogWarning(this.transform.name + ": LoadLevelText", this.gameObject);
    }
}