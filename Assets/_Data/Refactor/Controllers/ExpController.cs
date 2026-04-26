using System.Collections;
using _Data.Refactor.Controllers.Spawners;
using _Data.Refactor.Enums;
using Base.Systems.Level;
using Base.Utilities;
using UnityEngine;

namespace _Data.Refactor.Controllers
{
    public class ExpController : VyesBehaviour
    {
        [SerializeField] private ExpSpawner expSpawner;
        [SerializeField] private float expValue;

        private readonly ILevelService levelService = new LevelService();

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(nameof(TagEnum.Player)))
            {
                StartCoroutine(MoveTo(other.transform));
                ILevelUpAble levelUpAble = other.GetComponent<ILevelUpAble>();
                levelUpAble.AddExp(expValue);
                StopCoroutine(MoveTo(other.transform));
                expSpawner.Despawn(transform);
            }
        }

        IEnumerator MoveTo(Transform target)
        {
            float moveSpeed = 1f;
            while (Vector3.Distance(transform.position, target.position) > 0.1f)
            {
                transform.position =
                    Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * moveSpeed);
                moveSpeed *= 1.1f;
                yield return null;
            }
        }

        public void SetExpValue(float value)
        {
            expValue = value;
        }

        protected override void LoadComponents()
        {
            base.LoadComponents();
            if (expSpawner == null)
            {
                expSpawner = FindFirstObjectByType<ExpSpawner>();
                Debug.LogWarning($"Load {expSpawner}", gameObject);
            }
        }
    }
}