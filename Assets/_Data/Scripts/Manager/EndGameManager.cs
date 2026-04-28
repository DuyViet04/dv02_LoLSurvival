using _Data.Scripts.Manager;
using Base.Core.Singleton;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameManager : VyesPersistentSingleton<EndGameManager>
{
    [SerializeField] private Button exitButton;
    [SerializeField] private TMP_Text csPointText;
    private bool hasPlayedClip = false;

    public void Update()
    {
        if (SceneManager.GetActiveScene().name == nameof(ScenesEnum.GameOver))
        {
            this.LoadExitButton();
            this.LoadCSPointText();
            this.csPointText.text = $"Điểm CS: +{GameManager.Ins.CSCount}";
            if (!this.hasPlayedClip)
            {
                AudioManager.Ins.PlaySFXClip(nameof(AudioNameEnum.Defeat));
                this.hasPlayedClip = true;
            }
        }
        else if (SceneManager.GetActiveScene().name == nameof(ScenesEnum.GameVictory))
        {
            this.LoadExitButton();
            this.LoadCSPointText();
            this.csPointText.text = $"Điểm CS: +{GameManager.Ins.CSCount}";
            if (!this.hasPlayedClip)
            {
                AudioManager.Ins.PlaySFXClip(nameof(AudioNameEnum.Victory));
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
            this.exitButton.onClick.AddListener(() => SceneLevelManager.Ins.GoToScene(nameof(ScenesEnum.MainMenu)));
        }
    }

    void LoadExitButton()
    {
        if (this.exitButton != null) return;
        this.exitButton = GameObject.Find("ExitButton").GetComponent<Button>();
        Debug.LogWarning(this.transform.name + ": LoadExitButton", this.gameObject);
    }

    void LoadCSPointText()
    {
        if (this.csPointText != null) return;
        this.csPointText = GameObject.Find("CSPoint").GetComponent<TMP_Text>();
        Debug.LogWarning(this.transform.name + ": LoadCSPointText", this.gameObject);
    }
}