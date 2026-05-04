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

        private void OnEnable()
        {
            playButton.onClick.AddListener(PlayGame);
            quitButton.onClick.AddListener(QuitGame);
        }

        private void OnDisable()
        {
            playButton.onClick.RemoveListener(PlayGame);
            quitButton.onClick.RemoveListener(QuitGame);
        }

        public void PlayGame()
        {
            SoundManager.Ins.PlaySfx("Click");
            GameManager.Ins.LoadScene(GameState.GamePlay);
        }

        public void QuitGame()
        {
            SoundManager.Ins.PlaySfx("Click");
            Application.Quit();
        }
    }
}
