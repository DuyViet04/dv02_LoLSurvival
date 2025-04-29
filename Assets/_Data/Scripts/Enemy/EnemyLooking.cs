using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLooking : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void Update()
    {
        this.LookAtTarget();
    }

    void LookAtTarget()
    {
        Vector3 enemyPos = this.transform.parent.position;
        Vector3 targetPos = this.target.position;

        float x = targetPos.x - enemyPos.x;
        float z = targetPos.z - enemyPos.z;
        float angle = Mathf.Atan2(x, z) * Mathf.Rad2Deg;

        this.transform.parent.rotation = Quaternion.Euler(0, angle, 0);
    }
}