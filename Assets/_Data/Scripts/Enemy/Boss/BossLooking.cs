using UnityEngine;

public class BossLooking : LookingTarget
{
    [SerializeField] private Transform target;

    private void Update()
    {
        this.LookAtTarget(this.transform.parent, target);
    }
}