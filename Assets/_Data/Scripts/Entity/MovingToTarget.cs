using UnityEngine;

public abstract class MovingToTarget : VyesBehaviour
{
    [SerializeField] protected GameObject target;


    //Tự động đi về phía target
    protected virtual void MoveToTarget(float moveSpeed)
    {
        this.transform.parent.position =
            Vector3.MoveTowards(this.transform.parent.position, this.target.transform.position,
                moveSpeed * Time.deltaTime);
    }
}