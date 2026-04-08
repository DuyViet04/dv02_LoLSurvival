using System;
using UnityEngine;

namespace VyesBase.Systems.Level
{
    public class BaseLevel : MonoBehaviour
    {
        [Header("Current Status")] [SerializeField]
        private int currentLevel = 1;

        [SerializeField] private float currentExp = 0f;

        public event Action<int> OnLevelUp;
        public event Action<float, float> OnExpChanged;

        public int CurrentLevel => currentLevel;
        public float CurrentExp => currentExp;

        private ILevelService _levelService = new LevelService();

        private void Start()
        {
            UpdateUI();
        }

        public void AddExp(float amount)
        {
            if (amount <= 0 || currentLevel >= _levelService.MaxLevel) return;

            currentExp += amount;
            CheckLevelUp();
            UpdateUI();
        }

        private void CheckLevelUp()
        {
            float nextLevelExp = _levelService.GetExpRequiredForLevel(currentLevel + 1);

            while (currentExp >= nextLevelExp && currentLevel < _levelService.MaxLevel)
            {
                currentLevel++;
                OnLevelUp?.Invoke(currentLevel);

                if (currentLevel >= _levelService.MaxLevel) break;
                nextLevelExp = _levelService.GetExpRequiredForLevel(currentLevel + 1);
            }
        }

        public float GetRequiredExpForNextLevel()
        {
            return _levelService.GetExpRequiredForLevel(currentLevel + 1);
        }

        private void UpdateUI()
        {
            float requiredExp = GetRequiredExpForNextLevel();
            OnExpChanged?.Invoke(currentExp, requiredExp);
        }

        public void SetLevelService(ILevelService service)
        {
            _levelService = service;
        }
    }
}