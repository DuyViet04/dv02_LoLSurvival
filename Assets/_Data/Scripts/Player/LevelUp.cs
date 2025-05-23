using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class LevelUp : MonoBehaviour
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

    private void Awake()
    {
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
}