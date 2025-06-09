using UnityEngine;

public class BossLooking : LookingTarget
{
    [SerializeField] private Transform target;

    private void Update()
    {
        this.LookAtTarget(this.transform.parent, target);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadTarget();
    }

    void LoadTarget()
    {
        if (this.target != null) return;
        this.target = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.LogWarning(this.transform.name + ": LoadTarget", this.gameObject);
    }
}