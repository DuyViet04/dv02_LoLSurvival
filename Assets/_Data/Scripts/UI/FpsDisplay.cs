using System;
using TMPro;
using UnityEngine;

public class FpsDisplay : VyesBehaviour
{
    [SerializeField] private TMP_Text fpsText;
    private float deltaTime;

    private void Update()
    {
        this.deltaTime += (Time.unscaledDeltaTime - this.deltaTime) * 0.1f;
        float fps = 1.0f / this.deltaTime;
        this.fpsText.text = $"FPS: {fps:0}";
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFPSText();
    }

    void LoadFPSText()
    {
        if (this.fpsText != null) return;
        this.fpsText = GetComponentInChildren<TMP_Text>();
        Debug.LogWarning(this.transform.name + ": LoadFPSText", this.gameObject);
    }
}