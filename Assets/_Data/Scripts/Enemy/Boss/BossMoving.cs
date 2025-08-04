using UnityEngine;

public class BossMoving : MovingToTarget
{
    [SerializeField] private Animator animator;
    [SerializeField] private MainBossStats bossStats;
    private BossAttacking bossAttacking;
    private BossLooking bossLooking;
    private float moveSpeed;

    private void Awake()
    {
        this.bossAttacking = this.transform.parent.GetComponentInChildren<BossAttacking>();
        this.bossLooking = this.transform.parent.GetComponentInChildren<BossLooking>();
    }

    private void Update()
    {
        // Cập nhật tốc độ di chuyển dựa trên trạng thái tấn công của boss
        if (this.bossAttacking.IsAttacking)
        {
            this.moveSpeed = 0f; // Dừng di chuyển khi đang tấn công
            this.bossLooking.gameObject.SetActive(false);
        }
        else
        {
            this.moveSpeed = this.bossStats.moveSpeed;
            this.bossLooking.gameObject.SetActive(true);
        }

        this.MoveToTarget(this.moveSpeed);
        this.animator.SetFloat(nameof(AnimationParams.MovingSpeed), this.moveSpeed);
    }
}