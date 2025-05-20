using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingToTarget : MonoBehaviour
{
    [SerializeField] protected Transform target;
    
    protected virtual void MoveToTarget(float moveSpeed)
    {
        this.transform.parent.position =
            Vector3.MoveTowards(this.transform.parent.position, this.target.position,
                moveSpeed * Time.deltaTime);
    }
}