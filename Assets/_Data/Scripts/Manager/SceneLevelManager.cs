using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SceneLevelManager : VyesPersistentSingleton<SceneLevelManager>
{
    [SerializeField] private Button playButton;

    [FormerlySerializedAs("quitButton")] [SerializeField]
    private Button quitGameButton;

    private void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            this.LoadComponents();
        }

        if (this.playButton != null)
        {
            this.playButton.onClick.RemoveAllListeners();
            this.playButton.onClick.AddListener(() => this.GoToScene("GamePlay"));
        }

        if (this.quitGameButton != null)
        {
            this.quitGameButton.onClick.RemoveAllListeners();
            this.quitGameButton.onClick.AddListener(this.QuitGame);
        }
    }

    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayButton();
        this.LoadQuitGameButton();
    }

    private void LoadPlayButton()
    {
        if (this.playButton != null) return;
        this.playButton = GameObject.Find("PlayButton").GetComponent<Button>();
        Debug.LogWarning(this.transform.name + ": LoadPlayButton", this.gameObject);
    }

    void LoadQuitGameButton()
    {
        if (this.quitGameButton != null) return;
        this.quitGameButton = GameObject.Find("QuitGameButton").GetComponent<Button>();
        Debug.LogWarning(this.transform.name + ": LoadQuitGameButton", this.gameObject);
    }
}