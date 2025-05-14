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
}