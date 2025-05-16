using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text goldText;
    [SerializeField] private float startingGold = 500;
    [SerializeField] private float goldGeneration = 20.4f;
    private float currentGold;

    private void Start()
    {
        this.currentGold = startingGold;
    }

    private void Update()
    {
        this.currentGold += (this.goldGeneration / 10) * Time.deltaTime;
        float gold = Mathf.Round(this.currentGold);
        this.goldText.text = gold.ToString();
    }

    public void GiveGold(float value)
    {
        this.currentGold -= value;
        if (this.currentGold < 0) this.goldGeneration = 0;
    }

    public void Sell(float value)
    {
        this.currentGold += value * 0.7f;
    }

    public float GetCurrentGold()
    {
        return Mathf.Round(this.currentGold);
    }
}