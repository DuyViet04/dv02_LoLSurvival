using UnityEngine;

public class MeleeEnemyMoving : MovingToTarget
{
    [SerializeField] private MainEnemyStats stats;
    [SerializeField] private SOManager soManager;

    private void Update()
    {
        this.MoveToTarget(this.stats.moveSpeed);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadStats();
    }

    void LoadStats()
    {
        this.LoadSoManager();

        if (this.stats != null) return;
        this.stats = this.soManager.GetStatsByType(this.transform.parent.name);
        Debug.LogWarning(this.transform.name + ": LoadStats", this.gameObject);
    }

    void LoadSoManager()
    {
        if (this.soManager != null) return;
        this.soManager = GameObject.FindObjectOfType<SOManager>();
        Debug.LogWarning(this.transform.name + ": LoadSOManager", this.gameObject);
    }
}