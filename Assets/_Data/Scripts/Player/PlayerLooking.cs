using UnityEngine;

public class PlayerLooking : MonoBehaviour
{
    [SerializeField] private FindClosestEnemy findClosest;

    private void Update()
    {
        GameObject closestTarget = this.findClosest.GetClosestTarget();
        float dis = this.findClosest.GetDistanceToTarget();
        if (closestTarget == null) return;
        if (dis > 5) return;
        this.LookAtTarget(this.transform.parent, closestTarget.transform);
    }

    void LookAtTarget(Transform currentTrans, Transform target)
    {
        Vector3 direction = target.position - currentTrans.position;
        direction.y = 0f;

        if (direction == Vector3.zero) return;
        Quaternion targetRot = Quaternion.LookRotation(direction);

        currentTrans.rotation = Quaternion.RotateTowards(currentTrans.rotation, targetRot, Time.deltaTime * 180f);
    }
}