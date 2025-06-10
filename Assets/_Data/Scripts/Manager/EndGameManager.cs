using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameManager : VyesPersistentSingleton<EndGameManager>
{
    [SerializeField] private Button exitButton;
    private bool hasPlayedClip = false;

    public void Update()
    {
        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            this.LoadExitButton();
            if (!this.hasPlayedClip)
            {
                AudioManager.Instance.PlaySFXClip("Defeat");
                this.hasPlayedClip = true;
            }
        }
        else if (SceneManager.GetActiveScene().name == "GameVictory")
        {
            this.LoadExitButton();
            if (!this.hasPlayedClip)
            {
                AudioManager.Instance.PlaySFXClip("Victory");
                this.hasPlayedClip = true;
            }
        }
        else
        {
            this.hasPlayedClip = false;
        }

        if (this.exitButton != null)
        {
            this.exitButton.onClick.RemoveAllListeners();
            this.exitButton.onClick.AddListener(() => SceneLevelManager.Instance.GoToScene("MainMenu"));
        }
    }

    void LoadExitButton()
    {
        if (this.exitButton != null) return;
        this.exitButton = GameObject.Find("ExitButton").GetComponent<Button>();
        Debug.LogWarning(this.transform.name + ": LoadExitButton", this.gameObject);
    }
}