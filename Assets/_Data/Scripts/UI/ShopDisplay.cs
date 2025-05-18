using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ShopDisplay : MonoBehaviour
{
    private static ShopDisplay instance;
    public static ShopDisplay Instance => instance;

    [SerializeField] private ItemTable itemTable;
    [SerializeField] private ItemRarityTable itemRarityTable;
    [SerializeField] private GameObject core;
    [SerializeField] private GameObject core1;
    [SerializeField] private GameObject core2;
    [SerializeField] private GameObject shopPanel;
    public List<GameObject> coresList;
    private List<Image> coreIconList;
    private List<TMP_Text> coreNameList, coreStatsList, coreCostList;
    public List<ScriptableObject> choices;

    private void Awake()
    {
        if (instance != null) Debug.LogError("More than one ShopDisplay in scene.");
        instance = this;

        this.coresList = new List<GameObject> { this.core, this.core1, this.core2 };
        this.coreIconList = new List<Image>();
        this.coreNameList = new List<TMP_Text>();
        this.coreStatsList = new List<TMP_Text>();
        this.coreCostList = new List<TMP_Text>();
        this.choices = new List<ScriptableObject>();

        this.LoadCoresData();
    }

    public void ShowItemChoices()
    {
        foreach (GameObject core in this.coresList)
        {
            core.SetActive(true);
        }

        this.choices = this.GetRandomItems(3);
        this.coreIconList[0].sprite = ((ItemData)this.choices[0]).icon;
        this.coreNameList[0].text = ((ItemData)this.choices[0]).name;
        this.coreStatsList[0].text = ((ItemData)this.choices[0]).displayText;
        this.coreCostList[0].text = ((ItemData)this.choices[0]).cost.ToString();

        this.coreIconList[1].sprite = ((ItemData)this.choices[1]).icon;
        this.coreNameList[1].text = ((ItemData)this.choices[1]).name;
        this.coreStatsList[1].text = ((ItemData)this.choices[1]).displayText;
        this.coreCostList[1].text = ((ItemData)this.choices[1]).cost.ToString();

        this.coreIconList[2].sprite = ((ItemData)this.choices[2]).icon;
        this.coreNameList[2].text = ((ItemData)this.choices[2]).name;
        this.coreStatsList[2].text = ((ItemData)this.choices[2]).displayText;
        this.coreCostList[2].text = ((ItemData)this.choices[2]).cost.ToString();
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

    void LoadCoresData()
    {
        foreach (GameObject item in this.coresList)
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
}