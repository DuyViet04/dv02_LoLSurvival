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

    public void Update()
    {
        if ((SceneManager.GetActiveScene().name == "GameOver") || (SceneManager.GetActiveScene().name == "GameVictory"))
        {
            this.LoadExitButton();
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