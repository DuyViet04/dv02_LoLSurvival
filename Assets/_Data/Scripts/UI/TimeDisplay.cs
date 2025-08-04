using TMPro;
using UnityEngine;

public class TimeDisplay : MonoBehaviour
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

    public float GetTime()
    {
        return this.timer;
    }
}