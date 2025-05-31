using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameoverManager : VyesSingleton<GameoverManager>
{
    [SerializeField] private TMP_Text csText;

    private void Start()
    {
        int csCount = GameManager.Instance.CSCount;
        this.csText.text = $"CS: {csCount:0}";
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCSText();
    }

    void LoadCSText()
    {
        if (this.csText != null) return;
        this.csText = GameObject.Find("CSText").GetComponent<TMP_Text>();
        Debug.LogWarning(this.transform.name + ": LoadCSText", this.gameObject);
    }
}