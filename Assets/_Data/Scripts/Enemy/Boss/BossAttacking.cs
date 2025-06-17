using UnityEngine;

public class BossAttacking : VyesBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private BossAatroxSkill bossAatroxSkill;
    private float cooldownTimer;
    private bool isCooldown = false;
    private bool isAttacking = false;
    public bool IsAttacking => this.isAttacking;
    private string currentAnim;
    public string CurrentAnim => this.currentAnim;

    private void Update()
    {
        Transform target = GameObject.FindGameObjectWithTag("Player").transform;
        float dis = this.GetDistanceToTarget(target.position);

        // Kiểm tra trạng thái của Animator để xác định xem Boss có đang tấn công hay không
        AnimatorStateInfo stateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("Q1") || stateInfo.IsName("Q2") || stateInfo.IsName("Q3"))
        {
            this.isAttacking = true;
        }
        else
        {
            this.isAttacking = false;
        }

        this.currentAnim = this.GetCurrentAnim(stateInfo);// Lấy tên anim hiện tại

        // Nếu Boss đang tấn công, không cho phép tấn công tiếp
        if (this.isCooldown)
        {
            this.animator.ResetTrigger("IsAttack");
            this.cooldownTimer -= Time.deltaTime;
            if (this.cooldownTimer <= 0)
            {
                this.cooldownTimer = 0;
                this.isCooldown = false;
            }
        }
        else
        {
            if (dis > 5f) return;
            this.Attack();
        }
    }

    // Gọi skill tấn công
    void Attack()
    {
        if (this.isCooldown) return;
        this.animator.SetTrigger("IsAttack");
        this.isCooldown = true;
        this.cooldownTimer = this.bossAatroxSkill.bossAatroxSkillData[0].cooldown;
    }

    // Tính khoảng cách từ Boss đến target
    float GetDistanceToTarget(Vector3 targetPosition)
    {
        float distance = Vector3.Distance(this.transform.parent.position, targetPosition);
        return distance;
    }

    // Lấy tên anim hiện tại dựa trên AnimatorStateInfo
    string GetCurrentAnim(AnimatorStateInfo stateInfo)
    {
        if (stateInfo.IsName("Q1"))
        {
            return "Skill1";
        }
        else if (stateInfo.IsName("Q2"))
        {
            return "Skill1_1";
        }
        else if (stateInfo.IsName("Q3"))
        {
            return "Skill1_2";
        }

        return "Unknown";
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
        this.LoadBossAatroxSkill();
    }

    void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = this.transform.parent.GetComponentInChildren<Animator>();
        Debug.LogWarning(this.transform.name + ": LoadAnimator", this.gameObject);
    }

    void LoadBossAatroxSkill()
    {
        if (this.bossAatroxSkill != null) return;
        this.bossAatroxSkill = Resources.Load<BossAatroxSkill>("Skill/Boss/BossAatroxSkill");
        Debug.LogWarning(this.transform.name + ": LoadBossAatroxSkill", this.gameObject);
    }
}