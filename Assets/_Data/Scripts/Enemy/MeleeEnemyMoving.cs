using UnityEngine;

public class MeleeEnemyMoving : MovingToTarget
{
    [SerializeField] private MainEnemyStats stats;

    private void Update()
    {
        this.MoveToTarget(this.stats.moveSpeed);
    }
}