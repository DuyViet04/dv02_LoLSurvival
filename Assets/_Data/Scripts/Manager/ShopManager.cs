using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ShopManager : MonoBehaviour
{
    private static ShopManager instance;

    public static ShopManager Instance
    {
        get { return instance; }
    }

    [SerializeField] private GameObject shopPanel;
    [SerializeField] private ItemTable itemTable;
    [SerializeField] private ItemRarityTable itemRarityTable;
    [SerializeField] private GoldDisplay goldDisplay;
    [SerializeField] private GameObject itemSlot;
    [SerializeField] private GameObject core1;
    [SerializeField] private Image icon1;
    [SerializeField] private TMP_Text name1;
    [SerializeField] private TMP_Text stats1;
    [SerializeField] private TMP_Text cost1;
    [SerializeField] private GameObject core2;
    [SerializeField] private Image icon2;
    [SerializeField] private TMP_Text name2;
    [SerializeField] private TMP_Text stats2;
    [SerializeField] private TMP_Text cost2;
    [SerializeField] private GameObject core3;
    [SerializeField] private Image icon3;
    [SerializeField] private TMP_Text name3;
    [SerializeField] private TMP_Text stats3;
    [SerializeField] private TMP_Text cost3;
    private List<ScriptableObject> choices;
    private List<ItemData> inventory;
    private List<GameObject> cores;
    private int itemCount = 0;


    private void Awake()
    {
        if (instance != null) Debug.LogError("More than one Shop Manager in scene.");
        instance = this;

        this.inventory = new List<ItemData>();
        this.cores = new List<GameObject> { this.core1, this.core2, this.core3 };
    }

    public void OpenShop()
    {
        this.shopPanel.SetActive(true);
        Time.timeScale = 0;
        this.ShowItemChoices();
    }

    public void ExitShop()
    {
        this.shopPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void ShowItemChoices()
    {
        foreach (GameObject core in this.cores)
        {
            core.SetActive(true);
        }

        this.choices = this.GetRandomItems(3);
        this.icon1.sprite = ((ItemData)this.choices[0]).icon;
        this.name1.text = ((ItemData)this.choices[0]).name;
        this.stats1.text = ((ItemData)this.choices[0]).displayText;
        this.cost1.text = ((ItemData)this.choices[0]).cost.ToString();
        this.icon2.sprite = ((ItemData)this.choices[1]).icon;
        this.name2.text = ((ItemData)this.choices[1]).name;
        this.stats2.text = ((ItemData)this.choices[1]).displayText;
        this.cost2.text = ((ItemData)this.choices[1]).cost.ToString();
        this.icon3.sprite = ((ItemData)this.choices[2]).icon;
        this.name3.text = ((ItemData)this.choices[2]).name;
        this.stats3.text = ((ItemData)this.choices[2]).displayText;
        this.cost3.text = ((ItemData)this.choices[2]).cost.ToString();
    }

    public void BuyItem(int index)
    {
        List<Image> itemSlots = this.LoadItemSlot();
        ItemData item = (ItemData)this.choices[index];
        if (this.IsCanBuy(item, this.inventory))
        {
            this.goldDisplay.GiveGold(item.cost);
            this.inventory.Add(item);
            this.itemCount++;
            cores[index].SetActive(false);
            itemSlots[itemCount - 1].sprite = item.icon;
        }
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
        foreach (Transform itemSlot in this.itemSlot.transform)
        {
            Image img = itemSlot.GetComponent<Image>();
            itemSlots.Add(img);
        }

        return itemSlots;
    }

    List<ScriptableObject> GetRandomItems(int count)
    {
        List<ScriptableObject> copy = new List<ScriptableObject>(this.itemTable.items);
        List<ScriptableObject> result = new List<ScriptableObject>();

        for (int i = 0; i < count && copy.Count > 0; i++)
        {
            ItemRarityType rarity = this.itemRarityTable.GetRandomRarity();
            int index = Random.Range(0, copy.Count);
            result.Add(copy[index]);
        }

        return result;
    }
}