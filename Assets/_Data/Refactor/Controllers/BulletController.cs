using Base.Utilities;
using UnityEngine;

namespace _Data.Refactor.Controllers
{
    public class BulletController : VyesBehaviour
    {
        [SerializeField] private float moveSpeed;

        void Update()
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }
}