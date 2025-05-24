using UnityEngine;

public class RangeEnemyMoving : MovingToTarget
{
    [SerializeField] private MainEnemyStats stats;
    [SerializeField] private SOManager soManager;

    private void Update()
    {
        float dis = this.GetDistanceToTarget();

        float moveSpeed = dis < 10 ? 0f : this.stats.moveSpeed; // Nếu khoảng cách nhỏ hơn 10 thì dừng lại
        this.MoveToTarget(moveSpeed);
    }

    float GetDistanceToTarget()
    {
        float dis = Vector3.Distance(this.target.transform.position, this.transform.parent.position);
        return dis;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadStats();
        this.LoadTarget();
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

    void LoadTarget()
    {
        if (this.target != null) return;
        this.target = GameObject.FindGameObjectWithTag("Player");
    }
}