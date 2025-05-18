using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.Serialization;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject levelUpPanel;
    [SerializeField] private GameObject pauseGamePanel;
    private bool isLevelUp;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.PauseGame();
        }
    }

    void PauseGame()
    {
        this.isLevelUp = this.levelUpPanel.activeSelf;

        if (this.isLevelUp) this.levelUpPanel.SetActive(false);
        this.pauseGamePanel.SetActive(true);
        StatsDisplay.Instance.mainStatsPanel.SetActive(true);
        Time.timeScale = 0;
        StatsDisplay.Instance.UpdateMainData();
        StatsDisplay.Instance.UpdateSecondData();
    }

    public void ContinueGame()
    {
        this.pauseGamePanel.SetActive(false);
        Time.timeScale = 1;

        if (this.isLevelUp)
        {
            this.levelUpPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}