using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameoverManager : VyesSingleton<GameoverManager>
{
    [SerializeField] private Button exitButton;

    public void Exit()
    {
        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            this.LoadExitButton();
        }

        if (this.exitButton != null)
        {
            this.exitButton.onClick.RemoveAllListeners();
            this.exitButton.onClick.AddListener(() => SceneLevelManager.Instance.GoToScene("MainMenu"));
        }
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadExitButton();
    }

    void LoadExitButton()
    {
        if (this.exitButton != null) return;
        this.exitButton = GameObject.Find("ExitButton").GetComponent<Button>();
        Debug.LogWarning(this.transform.name + ": LoadExitButton", this.gameObject);
    }
}