using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyMoving : MonoBehaviour
{
    [SerializeField] private MeleeEnemyStats stats;
    [SerializeField] private Transform target;

    private void Update()
    {
        this.MoveToTarget();
    }

    void MoveToTarget()
    {
        this.transform.parent.position = Vector3.MoveTowards(this.transform.parent.position, this.target.position,
            this.stats.moveSpeed * Time.deltaTime);
    }
}