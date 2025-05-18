using System;
using TMPro;
using UnityEngine;

public class CSDisplay : MonoBehaviour
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
}