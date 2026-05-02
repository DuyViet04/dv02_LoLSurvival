using Base.Core.Architecture;
using Base.Systems.Economy;
using TMPro;
using UnityEngine;

namespace _Data.Refactor.Views.UIs
{
    public class GoldUi : BaseView
    {
        [SerializeField] private TMP_Text goldText;

        private void OnEnable()
        {
            GoldManager.Ins.OnGoldChanged += UpdateGold;
        }

        private void OnDisable()
        {
            GoldManager.Ins.OnGoldChanged -= UpdateGold;
        }

        void UpdateGold(float value)
        {
            goldText.text = $"{value:N0}";
        }
    }
}