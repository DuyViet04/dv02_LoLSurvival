using Base.Core.Architecture;
using Base.Systems.Sound;
using UnityEngine;
using UnityEngine.UI;
using VyesBase.Assets.Base.Systems.Game;

namespace _Data.Refactor.Views.Panels
{
    public class MainMenuPanel : BaseView
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Button quitButton;
        [SerializeField] private Button talentButton;
        [SerializeField] private Button settingButton;
        [SerializeField] private GameObject talentPanel;
        [SerializeField] private GameObject settingPanel;

        private void OnEnable()
        {
            playButton.onClick.AddListener(PlayGame);
            quitButton.onClick.AddListener(QuitGame);
            talentButton.onClick.AddListener(OpenTalentPanel);
            settingButton.onClick.AddListener(OpenSettingPanel);
        }

        private void OnDisable()
        {
            playButton.onClick.RemoveListener(PlayGame);
            quitButton.onClick.RemoveListener(QuitGame);
            talentButton.onClick.RemoveListener(OpenTalentPanel);
            settingButton.onClick.RemoveListener(OpenSettingPanel);
        }

        public void PlayGame()
        {
            SoundManager.Ins.PlaySfx("Click");
            GameManager.Ins.LoadScene(GameState.GamePlay);
        }

        public void OpenTalentPanel()
        {
            SoundManager.Ins.PlaySfx("Click");
            talentPanel.gameObject.SetActive(true);
        }

        public void QuitGame()
        {
            SoundManager.Ins.PlaySfx("Click");
            Application.Quit();
        }

        public void OpenSettingPanel()
        {
            SoundManager.Ins.PlaySfx("Click");
            settingPanel.gameObject.SetActive(true);
        }
    }
}