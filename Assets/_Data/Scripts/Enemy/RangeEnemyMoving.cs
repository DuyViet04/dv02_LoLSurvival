using UnityEngine;

public class RangeEnemyMoving : MovingToTarget
{
    [SerializeField] private MainEnemyStats stats;
    [SerializeField] private SOManager soManager;

    private void Awake()
    {
        this.stats = this.soManager.GetStatsByType(this.transform.parent.name);
    }

    private void Update()
    {
        float dis = this.GetDistanceToTarget();

        float moveSpeed = dis < 10 ? 0f : this.stats.moveSpeed;
        this.MoveToTarget(moveSpeed);
    }

    float GetDistanceToTarget()
    {
        float dis = Vector3.Distance(this.target.position, this.transform.parent.position);
        return dis;
    }
}