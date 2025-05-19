using System;
using UnityEngine;

public class MeleeEnemyMoving : MovingToTarget
{
    private MainEnemyStats stats;

    private void Awake()
    {
        this.stats = SOManager.Instance.GetStatsByType(this.transform.parent.name);
    }

    private void Update()
    {
        this.MoveToTarget(this.stats.moveSpeed);
        Debug.Log(this.stats.moveSpeed);
    }
}