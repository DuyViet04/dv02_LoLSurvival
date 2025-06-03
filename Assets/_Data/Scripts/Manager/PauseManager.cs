using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : VyesBehaviour
{
    [SerializeField] private GameObject levelUpPanel;
    [SerializeField] private GameObject pauseGamePanel;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject itemSlot;
    private List<Image> itemSlots;
    private List<Sprite> itemSprites;
    private bool isLevelUp;
    private bool isShopping;

    protected override void Awake()
    {
        base.Awake();
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

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLevelUpPanel();
        this.LoadGamePausePanel();
        this.LoadShopPanel();
        this.LoadItemSlot();
    }

    void LoadLevelUpPanel()
    {
        if (this.levelUpPanel != null) return;
        this.levelUpPanel = GameObject.Find("LevelUpPanel");
        Debug.LogWarning(this.transform.name + ": LoadLevelUpPanel", this.gameObject);
    }

    void LoadGamePausePanel()
    {
        if (this.pauseGamePanel != null) return;
        this.pauseGamePanel = GameObject.Find("PauseGamePanel");
        Debug.LogWarning(this.transform.name + ": LoadGamePausePanel", this.gameObject);
    }

    void LoadShopPanel()
    {
        if (this.shopPanel != null) return;
        this.shopPanel = GameObject.Find("ShopPanel");
        Debug.LogWarning(this.transform.name + ": LoadShopPanel", this.gameObject);
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

    void LoadItemSlot()
    {
        if (this.itemSlot != null) return;
        this.itemSlot = GameObject.Find("ItemSlot");
        Debug.LogWarning(this.transform.name + ": LoadItemSlot", this.gameObject);
    }
}