using _Data.Refactor.Controllers.Players;
using Base.Utilities;
using UnityEngine;

namespace _Data.Refactor.Controllers
{
    public class TornadoController : VyesBehaviour
    {
        [SerializeField] private PlayerController playerController;
        [SerializeField] private YasuoStats yasuoStats;
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