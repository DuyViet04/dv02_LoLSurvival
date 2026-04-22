using Base.Systems.Combat;
using UnityEngine;

namespace _Data.Refactor.Controllers.Players
{
    public class PlayerHealth : BaseHealth
    {
        [SerializeField] private PlayerController playerController;

        protected override void Awake()
        {
            health = playerController.CharacterRuntime.DefensiveData.Health;
            healthRegen = playerController.CharacterRuntime.DefensiveData.HealthRegen;
            base.Awake();
        }

        protected override void LoadComponents()
        {
            base.LoadComponents();
            if (playerController == null)
            {
                Debug.LogWarning($"Load {playerController}", gameObject);
                playerController = GetComponent<PlayerController>();
            }
        }
    }
}