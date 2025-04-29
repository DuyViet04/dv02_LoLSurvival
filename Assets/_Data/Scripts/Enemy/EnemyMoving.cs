using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float moveSpeed = 3f;

    private void Update()
    {
        this.MoveToTarget();
    }

    void MoveToTarget()
    {
        this.transform.parent.position = Vector3.MoveTowards(this.transform.parent.position, this.target.position, this.moveSpeed * Time.deltaTime);
    }
}
