using UnityEngine;

public class EnemyLooking : LookingTarget
{
    [SerializeField] protected GameObject target;

    private void Update()
    {
        this.LookAtTarget(this.transform.parent, this.target.transform);
    }
}