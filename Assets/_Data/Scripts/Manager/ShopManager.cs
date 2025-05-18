using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ShopManager : MonoBehaviour
{
    private static ShopManager instance;
    public static ShopManager Instance => instance;

    [SerializeField] private YasuoStats baseYasuoStats;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GoldDisplay goldDisplay;
    [SerializeField] private GameObject itemSlot;
    [SerializeField] private GameObject sellButton;
    [SerializeField] private Sprite itemBackground;
    private YasuoStats yasuoStats;
    private int itemCount = 0;
    private int indexItem;
    private List<ItemData> inventory;
    private List<Image> itemSlots;
    private List<Sprite> itemSprites;

    private void Awake()
    {
        if (instance != null) Debug.LogError("More than one Shop Manager in scene.");
        instance = this;

        this.yasuoStats = Instantiate(this.baseYasuoStats);

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
        this.itemSlots = this.LoadItemSlot();
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

    bool IsCanBuy(ItemData item, List<ItemData> inventory)
    {
        if (item.cost > this.goldDisplay.GetCurrentGold()) return false;
        if (inventory.Count >= 6) return false;
        return true;
    }

    List<Image> LoadItemSlot()
    {
        List<Image> itemSlots = new List<Image>();
        foreach (Transform item in this.itemSlot.transform)
        {
            Image itemImg = item.GetComponent<Image>();
            itemSlots.Add(itemImg);
        }

        return itemSlots;
    }
}