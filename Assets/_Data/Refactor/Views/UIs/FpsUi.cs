using Base.Core.Architecture;
using TMPro;
using UnityEngine;

namespace _Data.Refactor.Views.UIs
{
    public class FpsUi : BaseView
    {
        [SerializeField] private TMP_Text fpsText;
        private float deltaTime;

        private void Update()
        {
            deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
            float fps = 1.0f / this.deltaTime;
            fpsText.text = $"FPS: {fps:0}";
        }
    }
}