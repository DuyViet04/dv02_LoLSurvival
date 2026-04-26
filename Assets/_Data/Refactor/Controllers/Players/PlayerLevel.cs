using Base.Systems.Level;
using UnityEngine;

namespace _Data.Refactor.Controllers.Players
{
    public class PlayerLevel : BaseLevel
    {
        [SerializeField] private PlayerController playerController;

        protected override void Awake()
        {
            base.Awake();
            currentLevel = playerController.CharacterRuntime.LevelData.CurrentLevel;
            expMultiplier = playerController.CharacterRuntime.PlayerData.ExpMultiplier;
        }

        protected override void MaxExpCalculate(int currentLevel)
        {
            maxExp = 180 + currentLevel * 100f;
        }

        protected override void LoadComponents()
        {
            base.LoadComponents();
            if (playerController == null)
            {
                playerController = GetComponent<PlayerController>();
                Debug.LogWarning($"Load {playerController}", gameObject);
            }
        }
    }
}