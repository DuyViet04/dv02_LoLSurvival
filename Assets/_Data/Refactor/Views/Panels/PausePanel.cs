using Base.Core.Architecture;
using Base.Systems.Input;
using UnityEngine;
using VyesBase.Assets.Base.Systems.Game;

namespace _Data.Refactor.Views.Panels
{
    public class PausePanel : BaseView
    {
        [SerializeField] private GameObject pausePanel;
        [SerializeField] private GameObject levelUpPanel;
        [SerializeField] private GameObject shopPanel;
        [SerializeField] private GameObject settingPanel;
        private bool isLevelUpOpen;
        private bool isShopOpen;
        private bool isSettingOpen;

        private void Update()
        {
            if (InputManager.Ins.Pause || InputManager.Ins.UiPause)
            {
                if (pausePanel.activeSelf)
                {
                    HidePanel();
                }
                else
                {
                    ShowPanel();
                }
            }
        }

        private void ShowPanel()
        {
            GameManager.Ins.PauseGame();

            isLevelUpOpen = levelUpPanel.activeSelf;
            if (isLevelUpOpen)
            {
                levelUpPanel.SetActive(false);
            }

            isShopOpen = shopPanel.activeSelf;
            if (isShopOpen)
            {
                shopPanel.SetActive(false);
            }

            isSettingOpen = settingPanel.activeSelf;
            if (isSettingOpen)
            {
                settingPanel.SetActive(false);
            }

            pausePanel.SetActive(true);
        }

        public void HidePanel()
        {
            GameManager.Ins.ResumeGame();

            if (isLevelUpOpen)
            {
                levelUpPanel.SetActive(true);
                GameManager.Ins.PauseGame();
            }
            else if (isShopOpen)
            {
                shopPanel.SetActive(true);
                GameManager.Ins.PauseGame();
            }
            else if (isSettingOpen)
            {
                settingPanel.SetActive(true);
                GameManager.Ins.PauseGame();
            }

            pausePanel.SetActive(false);
        }
    }
}