using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUp : MonoBehaviour
{
    [SerializeField] private YasuoStats stats;
    [SerializeField] private RarityTable table;
    [SerializeField] private LevelUpManager levelUpManager;
    [SerializeField] private GameObject levelUpPanel;
    [SerializeField] private Image expBar;
    [SerializeField] private TMP_Text levelText;
    private float currentLv = 1;
    private float maxExp;
    private float currentExp;

    private void Start()
    {
        this.maxExp = 180 + 100 * Mathf.Pow(this.currentLv - 1, 2);
        this.currentExp = 0;
        this.expBar.fillAmount = this.currentExp / this.maxExp;
        this.levelText.SetText(this.currentLv.ToString());
    }

    public void IncreaseExp(float expValue)
    {
        this.currentExp += expValue * (1 + this.stats.expMultiplier / 100);
        this.expBar.fillAmount = this.currentExp / this.maxExp;

        if (this.currentExp >= this.maxExp)
        {
            this.IncreaseLevel();
        }
    }

    void IncreaseLevel()
    {
        this.IncreaseRarity(this.table);

        this.levelUpPanel.SetActive(true);
        Time.timeScale = 0;
        LevelUpManager.Instance.ShowUpgradeChoices();

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
        table.rarities[0].change -= progress * 10 / 15;
        table.rarities[1].change += progress * 4 / 15;
        table.rarities[2].change += progress * 3 / 15;
        table.rarities[3].change += progress * 2 / 15;
        table.rarities[4].change += progress * 1 / 15;
    }
}