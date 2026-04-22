using _Data.Refactor.Controllers.Spawners;
using _Data.Refactor.Enums;
using Base.Systems.Combat;
using Base.Utilities;
using UnityEngine;

namespace _Data.Refactor.Controllers
{
    public class BulletController : VyesBehaviour
    {
        [SerializeField] private BulletSpawner bulletSpawner;
        [SerializeField] private float moveSpeed;
        private AttackData attackData;

        public AttackData AttackData
        {
            set => attackData = value;
        }

        void Update()
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(nameof(TagEnum.Player)))
            {
                IDamageable damageable = other.GetComponent<IDamageable>();
                damageable.TakeDamage(attackData);
                bulletSpawner.Despawn(transform);
            }
        }

        protected override void LoadComponents()
        {
            base.LoadComponents();
            if (bulletSpawner == null)
            {
                bulletSpawner = GetComponentInParent<BulletSpawner>();
                Debug.LogWarning($"Load {bulletSpawner}", gameObject);
            }
        }
    }
}