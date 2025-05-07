using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUp : MonoBehaviour
{
    [SerializeField] private Image expBar;
    [SerializeField] private TMP_Text levelText;
    private float currentLv = 1;
    private float maxExp;
    private float currentExp;

    private void Start()
    {
        this.maxExp = Mathf.Pow(currentLv + 1, 2);
        this.currentExp = 0;
        this.expBar.fillAmount = this.currentExp / maxExp;
        this.levelText.SetText(this.currentLv.ToString());
    }

    public void IncreaseExp()
    {
        this.currentExp += 1;
        this.expBar.fillAmount = this.currentExp / maxExp;

        if (this.currentExp == this.maxExp)
        {
            this.IncreaseLevel();
        }
    }

    void IncreaseLevel()
    {
        this.currentLv++;
        this.maxExp = Mathf.Pow(currentLv + 1, 2);
        this.currentExp = 0;
        this.expBar.fillAmount = this.currentExp / maxExp;
        this.levelText.SetText(this.currentLv.ToString());
    }

    public float GetCurrentLevel()
    {
        return this.currentLv;
    }
}