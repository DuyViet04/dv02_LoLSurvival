using _Data.Refactor.Controllers.Players;
using _Data.Refactor.Enums;
using Base.Systems.Combat;
using Base.Utilities;
using UnityEngine;

namespace _Data.Refactor.Controllers
{
    public class WeaponController : VyesBehaviour
    {
        [SerializeField] private PlayerController playerController;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(nameof(TagEnum.Enemy)))
            {
                IDamageable damageable = other.GetComponent<IDamageable>();
                AttackData attackData = playerController.SkillAttackData;
                // Debug.Log(attackData.Damage);
                damageable.TakeDamage(attackData);
            }
        }

        protected override void LoadComponents()
        {
            base.LoadComponents();
            if (playerController == null)
            {
                playerController = FindFirstObjectByType<PlayerController>();
                Debug.LogWarning($"Load {playerController}", gameObject);
            }
        }
    }
}