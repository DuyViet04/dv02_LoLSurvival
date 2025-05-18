using System;
using TMPro;
using UnityEngine;

public class FpsDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text fpsText;
    private float deltaTime;

    private void Update()
    {
        this.deltaTime += (Time.unscaledDeltaTime - this.deltaTime) * 0.1f;
        float fps = 1.0f / this.deltaTime;
        this.fpsText.text = $"FPS: {fps:0}";
    }
}