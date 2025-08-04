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
        AudioManager.Instance.PlaySFXClip(nameof(AudioNameEnum.OpenShop));
        this.shopPanel.SetActive(true);
        Time.timeScale = 0;
        ShopDisplay.Instance.ShowItemChoices();
    }

    public void ExitShop()
    {
        AudioManager.Instance.PlaySFXClip(nameof(AudioNameEnum.CloseShop));
        this.shopPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void BuyItem(int index)
    {
        AudioManager.Instance.PlaySFXClip(nameof(AudioNameEnum.BuyItem));
        this.itemSlots = this.LoadItemSlots();
        ItemData item = ShopDisplay.Instance.choices[index];
        if (this.IsCanBuy(item, this.inventory))
        {
            this.goldDisplay.GiveGold(item.cost);
            this.inventory.Add(item);
            this.itemCount++;
            this.yasuoStats.ApplyItem(item);
            ShopDisplay.Instance.ListCores[index].SetActive(false);
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
        AudioManager.Instance.PlaySFXClip(nameof(AudioNameEnum.SellItem));
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

    public List<Sprite> GetLastItem()
    {
        return this.itemSprites;
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
}