using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject levelUpPanel;
    [SerializeField] private GameObject pauseGamePanel;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject itemSlot;
    public GameObject settingPanel;
    private List<Image> itemSlots;
    private List<Sprite> itemSprites;
    private bool isLevelUp;
    private bool isShopping;


    private void Awake()
    {
        this.itemSlots = this.LoadItemSlots();
        this.levelUpPanel.SetActive(false);
        this.pauseGamePanel.SetActive(false);
        this.shopPanel.SetActive(false);
    }

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

        this.UpdateItem();
        this.LoadSettingPanel();
    }

    public void ContinueGame()
    {
        AudioManager.Instance.PlaySFXClip(nameof(AudioNameEnum.Click));
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

    public void OpenSetting()
    {
        AudioManager.Instance.PlaySFXClip(nameof(AudioNameEnum.Click));
        this.settingPanel.SetActive(true);
    }

    public void ExitToMainMenu()
    {
        AudioManager.Instance.PlaySFXClip(nameof(AudioNameEnum.Click));
        Time.timeScale = 1;
        GameManager.Instance.CSCount = CSDisplay.Instance.CSCount;
        GameManager.Instance.MainStatsData = StatsDisplay.Instance.GetLastMainData();
        GameManager.Instance.SecondStatsData = StatsDisplay.Instance.GetLastSecondData();
        GameManager.Instance.ItemSprites = ShopManager.Instance.GetLastItem();
        SceneLevelManager.Instance.GoToScene(nameof(ScenesEnum.GameOver));
    }

    void UpdateItem()
    {
        List<Sprite> itemSlots = ShopManager.Instance.GetLastItem();
        for (int i = 0; i < itemSlots.Count; i++)
        {
            if (i < this.itemSlots.Count)
            {
                this.itemSlots[i].sprite = itemSlots[i];
            }
        }
    }

    List<Image> LoadItemSlots()
    {
        List<Image> list = new List<Image>();
        foreach (Transform item in this.itemSlot.transform)
        {
            Image itemImg = item.GetComponent<Image>();
            list.Add(itemImg);
        }

        return list;
    }

    void LoadSettingPanel()
    {
        if (this.settingPanel != null) return;
        this.settingPanel = SettingDisplay.Instance.SettingPanel;
        Debug.LogWarning(this.transform.name + ": LoadSettingPanel", this.gameObject);
    }
}