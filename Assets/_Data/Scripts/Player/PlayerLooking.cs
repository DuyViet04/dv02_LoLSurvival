using UnityEngine;

public class PlayerLooking : LookingTarget
{
    private void Update()
    {
        GameObject closestTarget = this.FindClosestTarget();
        if (closestTarget == null) return;
        this.LookAtTarget(this.transform.parent, closestTarget.transform);
    }

    protected override void LookAtTarget(Transform currentTrans, Transform target)
    {
        Vector3 direction = target.position - currentTrans.position;
        direction.y = 0f;

        if (direction == Vector3.zero) return;
        Quaternion targetRot = Quaternion.LookRotation(direction);

        currentTrans.rotation = Quaternion.RotateTowards(currentTrans.rotation, targetRot, Time.deltaTime * 180f);
    }

    GameObject FindClosestTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float minDist = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float dist = Vector3.Distance(this.transform.parent.position, enemy.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                closest = enemy;
            }
        }

        return closest;
    }
}