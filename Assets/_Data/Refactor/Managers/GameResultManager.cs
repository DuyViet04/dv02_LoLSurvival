using System.Collections.Generic;
using _Data.Refactor.Models.Runtimes.Players;
using _Data.Refactor.Models.SOs.Items;
using _Data.Refactor.Services.Talents;
using Base.Core.Singleton;
using Base.Systems.Sound;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VyesBase.Assets.Base.Systems.Game;

namespace _Data.Refactor.Managers
{
    public class GameResultManager : VyesPersistentSingleton<GameResultManager>
    {
        private float[] mainStats = new float[16];
        private float[] secondStats = new float[2];
        private float csCount = 0;
        private int level = 1;
        private bool hasResult = false;
        private List<ItemSo> savedItems = new List<ItemSo>();
        private Sprite defaultItemSprite;

        public float[] MainStats => mainStats;
        public float[] SecondStats => secondStats;
        public float CsCount => csCount;
        public int Level => level;
        public bool HasResult => hasResult;
        public List<ItemSo> SavedItems => savedItems;

        protected override void Awake()
        {
            base.Awake();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        public void SaveResult(BasePlayerRuntime runtime, float cs, List<ItemSo> items, Sprite defaultSprite)
        {
            level = runtime.LevelData.CurrentLevel;
            csCount = cs;
            savedItems = new List<ItemSo>(items);
            defaultItemSprite = defaultSprite;

            for (int i = 0; i < 16; i++) mainStats[i] = 0; // Reset cũ
            mainStats[0] = level;
            mainStats[1] = runtime.DefensiveData.Health.Value;
            mainStats[2] = runtime.DefensiveData.HealthRegen.Value;
            mainStats[3] = runtime.OffensiveData.AttackDamage.Value;
            mainStats[4] = runtime.OffensiveData.AbilityPower.Value;
            mainStats[5] = runtime.DefensiveData.Armor.Value;
            mainStats[6] = runtime.DefensiveData.MagicResist.Value;
            mainStats[7] = runtime.UtilityData.MoveSpeed.Value;
            mainStats[8] = runtime.OffensiveData.CritChance.Value;
            mainStats[9] = runtime.OffensiveData.CritDamage.Value;
            mainStats[10] = runtime.OffensiveData.ArmorPenetration.Value;
            mainStats[11] = runtime.OffensiveData.MagicPenetration.Value;
            mainStats[12] = runtime.OffensiveData.LifeSteal.Value;
            mainStats[13] = runtime.OffensiveData.Omnivamp.Value;
            mainStats[14] = runtime.UtilityData.Haste.Value;
            mainStats[15] = runtime.DefensiveData.HealPower.Value;

            secondStats[0] = runtime.PlayerData.PickUpRange.Value;
            secondStats[1] = runtime.PlayerData.ExpMultiplier.Value;

            hasResult = true;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == "GameWin" || scene.name == "GameLose")
            {
                SetupUI(scene.name);
            }
            else if (scene.name == "GamePlay")
            {
                hasResult = false;
            }
        }

        private void SetupUI(string sceneName)
        {
            Button exitButton = GameObject.Find("ExitButton").GetComponent<Button>();
            TMP_Text csPointText = GameObject.Find("CSPoint").GetComponent<TMP_Text>();

            csPointText.text = $"Điểm CS: +{csCount:N0}";

            exitButton.onClick.RemoveAllListeners();
            exitButton.onClick.AddListener(() =>
            {
                TalentService.Ins.AddCsPoints((int)csCount);
                GameManager.Ins.LoadScene(GameState.MainMenu);
            });

            for (int i = 0; i < 6; i++)
            {
                GameObject itemObj = GameObject.Find($"Item_{i}");
                if (itemObj == null) continue;

                Image img = itemObj.GetComponent<Image>();
                if (i < savedItems.Count)
                {
                    img.sprite = savedItems[i].itemData.icon;
                }
                else
                {
                    img.sprite = defaultItemSprite;
                }

                img.color = Color.white;
            }

            string clip = sceneName == "GameWin" ? "Victory" : "Defeat";
            SoundManager.Ins.PlaySfx(clip);
        }
    }
}