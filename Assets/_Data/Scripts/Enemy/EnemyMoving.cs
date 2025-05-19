using System;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    [SerializeField] private EnemyScaleStats scaleStats;
    [SerializeField] private Transform target;
    private MeleeEnemyStats meleeEnemyStats;

    private void Update()
    {
        this.meleeEnemyStats = this.scaleStats.GetStats();
        this.MoveToTarget();
    }

    void MoveToTarget()
    {
        this.transform.parent.position = Vector3.MoveTowards(this.transform.parent.position, this.target.position,
            this.meleeEnemyStats.moveSpeed * Time.deltaTime);
    }
}