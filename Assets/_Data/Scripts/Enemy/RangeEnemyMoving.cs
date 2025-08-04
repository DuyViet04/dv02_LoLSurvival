using UnityEngine;

public class RangeEnemyMoving : MovingToTarget
{
    [SerializeField] private MainEnemyStats stats;

    private void Update()
    {
        float dis = this.GetDistanceToTarget();

        float moveSpeed = dis < 10 ? 0f : this.stats.moveSpeed; // Nếu khoảng cách nhỏ hơn 10 thì dừng lại
        this.MoveToTarget(moveSpeed);
    }


    // Tính khoảng cách từ Enemy đến target
    float GetDistanceToTarget()
    {
        float dis = Vector3.Distance(this.target.transform.position, this.transform.parent.position);
        return dis;
    }
}