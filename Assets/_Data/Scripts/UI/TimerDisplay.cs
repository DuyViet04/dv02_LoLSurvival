using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    private float timer;

    private void Update()
    {
        this.timer += Time.deltaTime;
        int minutes = Mathf.FloorToInt(this.timer / 60f);
        int seconds = Mathf.FloorToInt(this.timer % 60f);
        this.text.text = $"{minutes:00}:{seconds:00}";
    }
}