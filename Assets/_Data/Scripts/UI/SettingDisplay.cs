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
    [SerializeField] private Slider totalVolumeSlider;
    public Slider TotalVolumeSlider => this.totalVolumeSlider;
    [SerializeField] private Slider musicVolumeSlider;
    public Slider MusicVolumeSlider => this.musicVolumeSlider;
    [SerializeField] private Slider sfxVolumeSlider;
    public Slider SFXVolumeSlider => this.sfxVolumeSlider;

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
        AudioManager.Instance.PlaySFXClip("Click");
    }

    public void CloseSettingPanel()
    {
        this.settingPanel.SetActive(false);
        AudioManager.Instance.PlaySFXClip("Click");
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSettingPanel();
        this.LoadMusicVolumeSlider();
        this.LoadSFXVolumeSlider();
        this.LoadTotalVolumeSlider();
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

    void LoadTotalVolumeSlider()
    {
        if (this.totalVolumeSlider != null) return;
        this.totalVolumeSlider = GameObject.Find("TotalMusic").GetComponentInChildren<Slider>();
        Debug.LogWarning(this.transform.name + ": LoadTotalVolumeSlider", this.gameObject);
    }

    void LoadMusicVolumeSlider()
    {
        if (this.musicVolumeSlider != null) return;
        this.musicVolumeSlider = GameObject.Find("Music").GetComponentInChildren<Slider>();
        Debug.LogWarning(this.transform.name + ": LoadMusicVolumeSlider", this.gameObject);
    }

    void LoadSFXVolumeSlider()
    {
        if (this.sfxVolumeSlider != null) return;
        this.sfxVolumeSlider = GameObject.Find("SFX").GetComponentInChildren<Slider>();
        Debug.LogWarning(this.transform.name + ": LoadSFXVolumeSlider", this.gameObject);
    }
}