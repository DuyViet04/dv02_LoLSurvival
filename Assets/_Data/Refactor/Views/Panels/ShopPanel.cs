using System;
using System.Collections.Generic;
using _Data.Refactor.Managers;
using _Data.Refactor.Models.SOs.Items;
using Base.Core.Architecture;
using Base.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using _Data.Refactor.Controllers.Players;
using Base.Systems.Economy;
using Base.Systems.Stat;

namespace _Data.Refactor.Views.Panels
{
    public class ShopPanel : BaseView
    {
        [SerializeField] private PlayerController playerController;
        [SerializeField] private List<GameObject> itemViews;
        [SerializeField] private List<Image> itemIcons;
        [SerializeField] private List<TMP_Text> itemNames;
        [SerializeField] private List<TMP_Text> itemStats;
        [SerializeField] private List<TMP_Text> itemPrices;
        [SerializeField] private List<Image> playerItemIcons;
        [Header("Buttons")] [SerializeField] private Button exitButton;
        [SerializeField] private Button sellButton;
        [SerializeField] private Button rollButton;
        [Header("Item View")] [SerializeField] private Sprite defaultItemIcon;
        private List<ItemSo> items;
        private List<ItemSo> itemChoices = new List<ItemSo>();
        private List<ItemSo> playerItems = new List<ItemSo>(6);
        private int itemIndex;

        private readonly IStatService statService = new StatService();

        protected override void Awake()
        {
            base.Awake();
            items = new List<ItemSo>(SoManager.Ins.ItemSos);
        }

        private void OnEnable()
        {
            ShowItems();
            sellButton.gameObject.SetActive(false);
        }

        public void ShowItems()
        {
            itemChoices = GetRandomItem(3);
            for (int i = 0; i < itemChoices.Count; i++)
            {
                itemViews[i].SetActive(true);
                itemIcons[i].sprite = itemChoices[i].itemData.icon;
                itemNames[i].text = itemChoices[i].itemData.itemName;
                itemStats[i].text = itemChoices[i].itemData.description;
                itemPrices[i].text = itemChoices[i].itemData.cost.ToString();
            }
        }

        public void ChoiceItem(int index)
        {
            ItemSo selectedItem = itemChoices[index];
            if (playerItems.Count >= 6 || !GoldManager.Ins.TryUseGold(selectedItem.itemData.cost)) return;
            foreach (var itemMod in selectedItem.itemData.statModifiers)
            {
                var stat = statService.FindStat(itemMod.type, playerController.CharacterRuntime);
                if (stat != null)
                {
                    var mod = itemMod.modifier;
                    var newMod = new StatModifier(mod.Value, mod.Type);
                    stat.AddModifier(newMod);
                }
            }

            playerItems.Add(selectedItem);
            UpdateItemView();
            itemViews[index].SetActive(false);
        }

        public void Roll()
        {
            ShowItems();
        }

        public void Sell()
        {
            var sellValue = playerItems[itemIndex].itemData.cost * 0.7f;
            GoldManager.Ins.AddGold(sellValue);
            playerItems.RemoveAt(itemIndex);
            UpdateItemView();
            sellButton.gameObject.SetActive(false);
        }

        public void Exit()
        {
            gameObject.SetActive(false);
        }

        public void OnItemIndexClick(int index)
        {
            if (index <= playerItems.Count)
            {
                itemIndex = index;
                sellButton.gameObject.SetActive(true);
            }
            else
            {
                sellButton.gameObject.SetActive(false);
            }
        }

        private void UpdateItemView()
        {
            for (int i = 0; i < 6; i++)
            {
                if (i < playerItems.Count)
                {
                    playerItemIcons[i].sprite = playerItems[i].itemData.icon;
                }
                else
                {
                    playerItemIcons[i].sprite = defaultItemIcon;
                }
            }
        }

        List<ItemSo> GetRandomItem(int count)
        {
            List<ItemSo> res = new List<ItemSo>();
            for (int i = 0; i < count; i++)
            {
                items.Shuffle();
                res.Add(items[0]);
            }

            return res;
        }
    }
}