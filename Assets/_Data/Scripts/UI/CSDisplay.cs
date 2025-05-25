using System;
using TMPro;
using UnityEngine;

public class CSDisplay : VyesSingleton<CSDisplay>
{
    [SerializeField] private TMP_Text csText;
    private int csCount = 0;

    private void Update()
    {
        this.csText.text = this.csCount.ToString();
    }

    public void IncreaseCsCount()
    {
        this.csCount += 1;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCSText();
    }

    void LoadCSText()
    {
        if (this.csText != null) return;
        this.csText = GetComponentInChildren<TMP_Text>();
        Debug.LogWarning(this.transform.name + ": LoadCSText", this.gameObject);
    }
}