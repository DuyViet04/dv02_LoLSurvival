using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject levelUpPanel;
    [SerializeField] private GameObject pauseGamePanel;
    [SerializeField] private GameObject shopPanel;
    private bool isLevelUp;
    private bool isShopping;

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
        this.isShopping = this.shopPanel.activeSelf;

        if (this.isLevelUp) this.levelUpPanel.SetActive(false);
        if (this.isShopping) this.shopPanel.SetActive(false);

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

        if (this.isShopping)
        {
            this.shopPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}