using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingDisplay : VyesBehaviour
{
    [SerializeField] private GameObject settingPanel;

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
}
