using Base.Core.Architecture;
using TMPro;
using UnityEngine;

namespace _Data.Refactor.Views.UIs
{
    public class TimeUi : BaseView
    {
        [SerializeField] private TMP_Text text;
        private float timer;

        private void Update()
        {
            timer += Time.deltaTime;
            int minutes = Mathf.FloorToInt(timer / 60f);
            int seconds = Mathf.FloorToInt(timer % 60f);
            text.text = $"{minutes:00}:{seconds:00}";
        }
    }
}