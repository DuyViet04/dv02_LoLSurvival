using System;
using UnityEngine;

public class MeleeEnemyMoving : MovingToTarget
{
    [SerializeField] private MainEnemyStats stats;
    [SerializeField] private SOManager soManager;

    private void Awake()
    {
        this.stats = this.soManager.GetStatsByType(this.transform.parent.name);
    }

    private void Update()
    {
        this.MoveToTarget(this.stats.moveSpeed);
    }
}