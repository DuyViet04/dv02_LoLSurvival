using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingDisplay : VyesPersistentSingleton<SettingDisplay>
{
    [SerializeField] private GameObject settingPanel;
    public GameObject SettingPanel => this.settingPanel;
    [SerializeField] private Button settingButton;

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            this.LoadSettingButton();
        }

        if (this.settingButton != null)
        {
            this.settingButton.onClick.RemoveAllListeners();
            this.settingButton.onClick.AddListener(this.OpenSettingPanel);
        }
    }

    protected override void Awake()
    {
        base.Awake();
        this.settingPanel.SetActive(false);
    }

    public void OpenSettingPanel()
    {
        this.settingPanel.SetActive(true);
    }

    public void CloseSettingPanel()
    {
        this.settingPanel.SetActive(false);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSettingPanel();
    }

    void LoadSettingPanel()
    {
        if (this.settingPanel != null) return;
        this.settingPanel = GameObject.Find("SettingPanel");
        Debug.LogWarning(this.transform.name + ": LoadSettingPanel", this.gameObject);
    }

    void LoadSettingButton()
    {
        if (this.settingButton != null) return;
        this.settingButton = GameObject.Find("SettingButton").GetComponent<Button>();
        Debug.LogWarning(this.transform.name + ": LoadSettingButton", this.gameObject);
    }
}