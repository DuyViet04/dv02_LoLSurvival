using _Data.Refactor.Enums;
using Base.Systems.Combat;
using Base.Utilities;
using UnityEngine;

namespace _Data.Refactor.Controllers.Bosses
{
    public class BossWeaponController : VyesBehaviour
    {
        [SerializeField] private BossController bossController;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(nameof(TagEnum.Player)))
            {
                IDamageable damageable = other.GetComponent<IDamageable>();
                damageable.TakeDamage(bossController.BossRuntime.AttackData);
            }
        }
    }
}
