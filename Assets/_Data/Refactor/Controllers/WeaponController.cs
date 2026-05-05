using _Data.Refactor.Controllers.Players;
using _Data.Refactor.Enums;
using Base.Systems.Combat;
using Base.Systems.Skill;
using Base.Utilities;
using UnityEngine;

namespace _Data.Refactor.Controllers
{
    public class WeaponController : VyesBehaviour
    {
        [SerializeField] private PlayerController playerController;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(nameof(TagEnum.Enemy)) || other.CompareTag(nameof(TagEnum.Boss)))
            {
                IDamageable damageable = other.GetComponent<IDamageable>();
                AttackData attackData = playerController.SkillAttackData;
                float damageDealt = damageable.TakeDamage(attackData);
                PlayerHealth playerHealth = playerController.PlayerHealth;
                playerHealth.Heal(damageDealt, attackData, playerHealth.HealData, (SkillType)attackData.Source);
            }
        }
    }
}