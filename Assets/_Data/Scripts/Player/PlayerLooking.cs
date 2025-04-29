using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerLooking : LookingTarget
{
    private void Update()
    {
        GameObject closestTarget = this.FindClosestTarget();
        if (closestTarget == null) return;
        this.LookAtTarget(this.transform.parent, closestTarget.transform);
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