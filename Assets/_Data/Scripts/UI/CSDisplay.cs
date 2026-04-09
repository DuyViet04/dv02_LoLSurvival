using TMPro;
using UnityEngine;
using VyesBase.Core.Singleton;

public class CSDisplay : VyesSingleton<CSDisplay>
{
    [SerializeField] private TMP_Text csText;
    private int csCount = 0;
    public int CSCount => this.csCount;

    private void Update()
    {
        this.csText.text = this.csCount.ToString();
    }

    public void IncreaseCsCount()
    {
        this.csCount += 1;
    }
}