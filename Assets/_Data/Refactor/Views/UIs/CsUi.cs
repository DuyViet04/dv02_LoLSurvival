using Base.Core.Architecture;
using TMPro;
using UnityEngine;

namespace _Data.Refactor.Views.UIs
{
    public class CsUi : BaseView
    {
        [SerializeField] private TMP_Text csText;
        private float csCount = 0;

        public void UpdateCsCount(float value)
        {
            csCount += value;
            csText.text = $"{csCount:N0}";
        }
    }
}