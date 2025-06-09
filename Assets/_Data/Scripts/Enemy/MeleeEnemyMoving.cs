using UnityEngine;

public class MeleeEnemyMoving : MovingToTarget
{
    [SerializeField] private MainEnemyStats stats;

    private void Update()
    {
        this.MoveToTarget(this.stats.moveSpeed);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadStats();
        this.LoadTarget();
    }

    void LoadStats()
    {
        if (this.stats != null) return;
        this.stats = SOManager.Instance.GetEnemyStatsByType(this.transform.parent.name);
        Debug.LogWarning(this.transform.name + ": LoadStats", this.gameObject);
    }
    void LoadTarget()
    {
        if (this.target != null) return;
        this.target = GameObject.FindGameObjectWithTag("Player");
    }
}