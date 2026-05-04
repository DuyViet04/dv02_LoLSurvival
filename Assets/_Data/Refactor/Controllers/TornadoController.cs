using _Data.Refactor.Controllers.Players;
using _Data.Refactor.Enums;
using Base.Systems.Combat;
using Base.Systems.Skill;
using Base.Utilities;
using UnityEngine;

namespace _Data.Refactor.Controllers
{
    public class TornadoController : VyesBehaviour
    {
        [SerializeField] private PlayerController playerController;
        [SerializeField] private float distance = 15f;
        private float currentDis = 0f;

        private void Update()
        {
            Move();
        }

        void Move()
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 12f);
            currentDis += (Vector3.forward * Time.deltaTime * 12f).magnitude;
            if (currentDis >= distance)
            {
                currentDis = 0f;
                playerController.VfxSpawner.Despawn(transform);
            }
        }

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