using UnityEngine;

public class BossMoving : MovingToTarget
{
    [SerializeField] private Animator animator;
    [SerializeField] private MainBossStats bossStats;
    private BossAttacking bossAttacking;
    private BossLooking bossLooking;
    private float moveSpeed;

    protected override void Awake()
    {
        base.Awake();
        this.bossAttacking = this.transform.parent.GetComponentInChildren<BossAttacking>();
        this.bossLooking = this.transform.parent.GetComponentInChildren<BossLooking>();
    }

    private void Update()
    {
        if (this.bossAttacking.IsAttacking)
        {
            this.moveSpeed = 0f;
            this.bossLooking.gameObject.SetActive(false);
        }
        else
        {
            this.moveSpeed = this.bossStats.moveSpeed;
            this.bossLooking.gameObject.SetActive(true);
        }

        this.MoveToTarget(this.moveSpeed);
        this.animator.SetFloat("MoveSpeed", this.moveSpeed);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTarget();
        this.LoadAnimator();
        this.LoadBossStats();
    }

    void LoadTarget()
    {
        if (this.target != null) return;
        this.target = GameObject.FindGameObjectWithTag("Player");
        Debug.LogWarning(this.transform.name + ": LoadTarget", this.gameObject);
    }

    void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = this.transform.parent.GetComponentInChildren<Animator>();
        Debug.LogWarning(this.transform.name + ": LoadAnimator", this.gameObject);
    }

    void LoadBossStats()
    {
        if (this.bossStats != null) return;
        this.bossStats = SOManager.Instance.GetBossStatsByType(this.transform.parent.name);
        Debug.LogWarning(this.transform.name + ": LoadBossStats", this.gameObject);
    }
}