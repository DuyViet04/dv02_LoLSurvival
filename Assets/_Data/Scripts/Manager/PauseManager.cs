using UnityEngine;

public class PauseManager : VyesBehaviour
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

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLevelUpPanel();
        this.LoadGamePausePanel();
        this.LoadShopPanel();
    }

    void LoadLevelUpPanel()
    {
        if (this.levelUpPanel != null) return;
        this.levelUpPanel = GameObject.Find("LevelUpPanel");
        Debug.LogWarning(this.transform.name + ": LoadLevelUpPanel", this.gameObject);
        this.levelUpPanel.SetActive(false);
    }

    void LoadGamePausePanel()
    {
        if (this.pauseGamePanel != null) return;
        this.pauseGamePanel = GameObject.Find("PauseGamePanel");
        Debug.LogWarning(this.transform.name + ": LoadGamePausePanel", this.gameObject);
        this.pauseGamePanel.SetActive(false);
    }

    void LoadShopPanel()
    {
        if (this.shopPanel != null) return;
        this.shopPanel = GameObject.Find("ShopPanel");
        Debug.LogWarning(this.transform.name + ": LoadShopPanel", this.gameObject);
        this.shopPanel.SetActive(false);
    }
}