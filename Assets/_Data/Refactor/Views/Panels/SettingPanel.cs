using Base.Core.Architecture;
using Base.Systems.Sound;
using UnityEngine;
using UnityEngine.UI;

namespace _Data.Refactor.Views.Panels
{
    public class SettingPanel : BaseView
    {
        [Header("Sound")] [SerializeField] private Slider totalVolumeSlider;
        [SerializeField] private Slider musicVolumeSlider;
        [SerializeField] private Slider sfxVolumeSlider;
        [Header("Button")] [SerializeField] private Button closeButton;

        private void OnEnable()
        {
            totalVolumeSlider.onValueChanged.AddListener(SoundManager.Ins.UpdateTotalVolume);
            musicVolumeSlider.onValueChanged.AddListener(SoundManager.Ins.UpdateMusicVolume);
            sfxVolumeSlider.onValueChanged.AddListener(SoundManager.Ins.UpdateSfxVolume);
        }

        private void OnDisable()
        {
            totalVolumeSlider.onValueChanged.RemoveListener(SoundManager.Ins.UpdateTotalVolume);
            musicVolumeSlider.onValueChanged.RemoveListener(SoundManager.Ins.UpdateMusicVolume);
            sfxVolumeSlider.onValueChanged.RemoveListener(SoundManager.Ins.UpdateSfxVolume);
        }

        public void Exit()
        {
            SoundManager.Ins.PlaySfx("Click");
            gameObject.SetActive(false);
        }
    }
}