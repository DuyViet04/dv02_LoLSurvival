using UnityEngine;

public class FindClosestEnemy : MonoBehaviour
{
    public float GetDistanceToTarget()
    {
        GameObject closestTarget = this.FindClosestTarget();
        if (closestTarget == null) return float.MaxValue;
        float dis = Vector3.Distance(this.transform.parent.position, closestTarget.transform.position);
        return dis;
    }

    public GameObject GetClosestTarget()
    {
        return this.FindClosestTarget();
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