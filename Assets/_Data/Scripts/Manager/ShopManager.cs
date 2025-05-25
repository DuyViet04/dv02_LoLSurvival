using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : VyesSingleton<ShopManager>
{
    [SerializeField] private YasuoStats yasuoStats;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GoldDisplay goldDisplay;
    [SerializeField] private GameObject itemSlot;
    [SerializeField] private GameObject sellButton;
    [SerializeField] private Sprite itemBackground;
    private int itemCount = 0;
    private int indexItem;
    private List<ItemData> inventory;
    private List<Image> itemSlots;
    private List<Sprite> itemSprites;

    protected override void Awake()
    {
        base.Awake();
        this.shopPanel.SetActive(false);
        this.inventory = new List<ItemData>();
        this.itemSprites = new List<Sprite>();
    }

    public void OpenShop()
    {
        this.shopPanel.SetActive(true);
        Time.timeScale = 0;
        ShopDisplay.Instance.ShowItemChoices();
    }

    public void ExitShop()
    {
        this.shopPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void BuyItem(int index)
    {
        this.itemSlots = this.LoadItemSlots();
        ItemData item = (ItemData)ShopDisplay.Instance.choices[index];
        if (this.IsCanBuy(item, this.inventory))
        {
            this.goldDisplay.GiveGold(item.cost);
            this.inventory.Add(item);
            this.itemCount++;
            this.yasuoStats.ApplyItem(item);
            ShopDisplay.Instance.coresList[index].SetActive(false);
            this.itemSlots[this.itemCount - 1].sprite = item.icon;
            this.itemSprites.Add(item.icon);
        }
    }

    public void ShowSellButton(int index)
    {
        this.indexItem = index;
        this.sellButton.SetActive(true);
    }

    public void SellItem()
    {
        ItemData item = this.inventory[this.indexItem];
        this.goldDisplay.Sell(item.cost);
        this.itemCount--;
        this.yasuoStats.RemoveItem(this.inventory[this.indexItem]);
        this.inventory.Remove(this.inventory[this.indexItem]);
        this.itemSprites.Remove(this.itemSlots[this.indexItem].sprite);
        for (int i = this.indexItem; i < this.itemSprites.Count; i++)
        {
            this.itemSlots[i].sprite = this.itemSprites[i];
        }

        this.itemSlots[this.itemCount].sprite = this.itemBackground;
        this.sellButton.SetActive(false);
    }

    bool IsCanBuy(ItemData item, List<ItemData> inv)
    {
        if (item.cost > this.goldDisplay.GetCurrentGold()) return false;
        if (inv.Count >= 6) return false;
        return true;
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

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadYasuoStats();
        this.LoadShopPanel();
        this.LoadGoldDisplay();
        this.LoadItemSlot();
        this.LoadSellButton();
        this.LoadItemBackground();
    }

    void LoadYasuoStats()
    {
        if (this.yasuoStats != null) return;
        string[] guid = AssetDatabase.FindAssets("t:YasuoStats", new[] { "Assets/_Data/Scripts/Stat/Character/SO" });
        string path = AssetDatabase.GUIDToAssetPath(guid[0]);
        this.yasuoStats = AssetDatabase.LoadAssetAtPath<YasuoStats>(path);
        Debug.LogWarning(this.transform.name + ": LoadYasuoStats", this.gameObject);
    }

    void LoadShopPanel()
    {
        if (this.shopPanel != null) return;
        this.shopPanel = GameObject.Find("ShopPanel");
        Debug.LogWarning(this.transform.name + ": LoadShopPanel", this.gameObject);
    }

    void LoadGoldDisplay()
    {
        if (this.goldDisplay != null) return;
        this.goldDisplay = FindObjectOfType<GoldDisplay>();
        Debug.LogWarning(this.transform.name + ": LoadGoldDisplay", this.gameObject);
    }

    void LoadItemSlot()
    {
        if (this.itemSlot != null) return;
        this.itemSlot = GameObject.Find("ItemSlot");
        Debug.LogWarning(this.transform.name + ": LoadItemSlot", this.gameObject);
    }

    void LoadSellButton()
    {
        if (this.sellButton != null) return;
        this.sellButton = GameObject.Find("SellButton");
        Debug.LogWarning(this.transform.name + ": LoadSellButton", this.gameObject);
    }

    void LoadItemBackground()
    {
        if (this.itemBackground != null) return;
        string path = "Assets/_Data/Sprites/LoLHUD.png";
        this.itemBackground = SpriteFinder.GetSprite(path, "ItemBackground");
        Debug.LogWarning(this.transform.name + ": LoadItemBackground", this.gameObject);
    }
}