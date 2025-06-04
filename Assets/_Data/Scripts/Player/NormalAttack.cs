using UnityEngine;

public class NormalAttack : VyesBehaviour
{
    [SerializeField] private YasuoStats yasuoStats;
    [SerializeField] private YasuoSkill yasuoSkill;
    [SerializeField] private Animator animator;
    private float cooldownTime;
    private float cooldownTimer;
    private bool isCooldown = true;

    private void Update()
    {
        if (Time.timeScale == 0) return;

        this.cooldownTime =
            CooldownCalculator.GetCooldown(this.yasuoSkill.yasuoSkillData[0].cooldown, this.yasuoStats.haste);

        if (this.isCooldown && (!Input.GetMouseButtonDown(0) && !Input.GetMouseButtonDown(1)))
        {
            this.animator.SetInteger("currentSkill", 3);
            this.cooldownTimer -= Time.deltaTime;
            if (this.cooldownTimer <= 0)
            {
                this.cooldownTimer = 0;
                this.isCooldown = false;
            }
        }
        else
        {
            this.Attack();
        }
    }

    void Attack()
    {
        if (this.isCooldown) return;
        this.yasuoSkill.lastSkillIndex = 0;
        this.animator.SetInteger("currentSkill", 0);
        this.isCooldown = true;
        this.cooldownTimer = this.cooldownTime;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadYasuoStats();
        this.LoadYasuoSkill();
        this.LoadAnimator();
    }

    void LoadYasuoStats()
    {
        if (this.yasuoStats != null) return;
        this.yasuoStats = SOManager.Instance.GetYasuoStats();
        Debug.LogWarning(this.transform.name + ": LoadYasuoStats", this.gameObject);
    }

    void LoadYasuoSkill()
    {
        if (this.yasuoSkill != null) return;
        this.yasuoSkill = SOManager.Instance.GetYasuoSkill();
        Debug.LogWarning(this.transform.name + ": LoadYasuoSkill", this.gameObject);
    }

    void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = this.transform.parent.GetComponentInChildren<Animator>();
        Debug.LogWarning(this.transform.name + ": LoadAnimator", this.gameObject);
    }
}