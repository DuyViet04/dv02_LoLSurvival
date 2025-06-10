using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : VyesPersistentSingleton<AudioManager>
{
    [SerializeField] private List<AudioClip> audioClips;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    protected override void Awake()
    {
        base.Awake();
        this.PlayMusicClip("ThemeGame");
    }

    private void Update()
    {
        float totalVolume = SettingDisplay.Instance.TotalVolumeSlider.value;
        float musicVolume = SettingDisplay.Instance.MusicVolumeSlider.value;
        float sfxVolume = SettingDisplay.Instance.SFXVolumeSlider.value;

        this.musicSource.volume = totalVolume * musicVolume;
        this.sfxSource.volume = totalVolume * sfxVolume;
    }

    private void PlayMusicClip(string clipName)
    {
        AudioClip clip = this.GetClipByName(clipName);
        if (clip == null)
        {
            Debug.LogError("Audio clip not found: " + clipName);
        }
        else
        {
            this.musicSource.clip = clip;
            this.musicSource.Play();
            this.musicSource.loop = true;
        }
    }

    public void PlaySFXClip(string clipName)
    {
        AudioClip clip = this.GetClipByName(clipName);
        if (clip == null)
        {
            Debug.LogError("Audio clip not found: " + clipName);
        }
        else
        {
            this.sfxSource.PlayOneShot(clip);
        }
    }

    AudioClip GetClipByName(string name)
    {
        foreach (AudioClip clip in this.audioClips)
        {
            if (clip.name == name)
            {
                return clip;
            }
        }

        return null;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAudioClips();
        this.LoadMusicSource();
        this.LoadSFXSource();
    }

    void LoadAudioClips()
    {
        this.audioClips = new List<AudioClip>();
        AudioClip[] clipsList = Resources.LoadAll<AudioClip>("Audio");
        foreach (AudioClip clip in clipsList)
        {
            this.audioClips.Add(clip);
        }
    }

    void LoadMusicSource()
    {
        if (this.musicSource != null) return;
        this.musicSource = this.transform.Find("MusicSource").GetComponent<AudioSource>();
        Debug.LogWarning(this.transform.name + ": LoadMusicSource", this.gameObject);
    }

    void LoadSFXSource()
    {
        if (this.sfxSource != null) return;
        this.sfxSource = this.transform.Find("SFXSource").GetComponent<AudioSource>();
        Debug.LogWarning(this.transform.name + ": LoadSFXSource", this.gameObject);
    }
}