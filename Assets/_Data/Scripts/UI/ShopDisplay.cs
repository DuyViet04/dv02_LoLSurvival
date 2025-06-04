using System;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ShopDisplay : VyesSingleton<ShopDisplay>
{
    [SerializeField] private ItemTable itemTable;
    [SerializeField] private ItemRarityTable itemRarityTable;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private List<GameObject> listCores;
    public List<GameObject> ListCores => this.listCores;
    private List<Image> coreIconList;
    private List<TMP_Text> coreNameList, coreStatsList, coreCostList;
    public List<ItemData> choices;


    protected override void Awake()
    {
        base.Awake();
        this.coreIconList = new List<Image>();
        this.coreNameList = new List<TMP_Text>();
        this.coreStatsList = new List<TMP_Text>();
        this.coreCostList = new List<TMP_Text>();
        this.choices = new List<ItemData>();
        this.LoadCoresData();
    }

    public void ShowItemChoices()
    {
        foreach (GameObject core in this.listCores)
        {
            core.SetActive(true);
        }

        this.choices = this.GetRandomItems(3);
        this.coreIconList[0].sprite = this.choices[0].icon;
        this.coreNameList[0].text = this.choices[0].itemName;
        this.coreStatsList[0].text = this.choices[0].displayText;
        this.coreCostList[0].text = this.choices[0].cost.ToString();

        this.coreIconList[1].sprite = this.choices[1].icon;
        this.coreNameList[1].text = this.choices[1].itemName;
        this.coreStatsList[1].text = this.choices[1].displayText;
        this.coreCostList[1].text = this.choices[1].cost.ToString();

        this.coreIconList[2].sprite = this.choices[2].icon;
        this.coreNameList[2].text = this.choices[2].itemName;
        this.coreStatsList[2].text = this.choices[2].displayText;
        this.coreCostList[2].text = this.choices[2].cost.ToString();
    }

    List<ItemData> GetRandomItems(int count)
    {
        List<ItemData> copy = new List<ItemData>(this.itemTable.items);
        List<ItemData> result = new List<ItemData>();

        for (int i = 0; i < count && copy.Count > 0; i++)
        {
            ItemRarityType rarity = this.itemRarityTable.GetRandomRarity();
            int index = Random.Range(0, copy.Count);
            result.Add(copy[index]);
        }

        return result;
    }

    void LoadCoresData()
    {
        foreach (GameObject item in this.listCores)
        {
            Image itemImage = item.transform.Find("Icon").GetComponent<Image>();
            TMP_Text itemName = item.transform.Find("Name").GetComponent<TMP_Text>();
            TMP_Text itemStats = item.transform.Find("Stats").GetComponent<TMP_Text>();
            TMP_Text itemCost = item.transform.Find("Cost").GetComponent<TMP_Text>();

            this.coreIconList.Add(itemImage);
            this.coreNameList.Add(itemName);
            this.coreStatsList.Add(itemStats);
            this.coreCostList.Add(itemCost);
        }
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShopPanel();
        this.LoadItemTable();
        this.LoadItemRarityTable();
        this.LoadListCores();
    }

    void LoadItemTable()
    {
        if (this.itemTable != null) return;
        this.itemTable = Resources.Load<ItemTable>("Item/ItemTable");
        Debug.LogWarning(this.transform.name + ": LoadItemTable", this.gameObject);
    }

    void LoadItemRarityTable()
    {
        if (this.itemRarityTable != null) return;
        this.itemRarityTable = Resources.Load<ItemRarityTable>("Item/ItemRarityTable");
        Debug.LogWarning(this.transform.name + ": LoadItemRarityTable", this.gameObject);
    }

    void LoadListCores()
    {
        this.listCores = new List<GameObject>
        {
            this.transform.Find("Core").gameObject,
            this.transform.Find("Core_1").gameObject,
            this.transform.Find("Core_2").gameObject,
        };
    }

    void LoadShopPanel()
    {
        if (this.shopPanel != null) return;
        this.shopPanel = GameObject.Find("ShopPanel");
        Debug.LogWarning(this.transform.name + ": LoadShopPanel", this.gameObject);
    }
}