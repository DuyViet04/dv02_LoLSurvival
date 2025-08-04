using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemEndgameDisplay : MonoBehaviour

{
    [SerializeField] private GameObject itemSlot;
    private List<Image> itemSlots;

    private void Awake()
    {
        this.itemSlots = this.LoadItemSlots();
    }

    private void Start()
    {
        this.UpdateItemSlots();
    }

    void UpdateItemSlots()
    {
        List<Sprite> itemSlots = GameManager.Instance.ItemSprites;
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
}