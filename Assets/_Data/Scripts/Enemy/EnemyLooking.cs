using UnityEngine;

public class EnemyLooking : LookingTarget
{
    [SerializeField] protected GameObject target;

    private void Update()
    {
        this.LookAtTarget(this.transform.parent, this.target.transform);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTarget();
    }

    void LoadTarget()
    {
        if (this.target != null) return;
        this.target = GameObject.FindGameObjectWithTag("Player");
        Debug.LogWarning(this.transform.name + ": LoadTarget", this.gameObject);
    }
}