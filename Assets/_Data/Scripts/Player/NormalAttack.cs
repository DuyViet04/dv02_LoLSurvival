using UnityEngine;

public class NormalAttack : MonoBehaviour
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

        // Tính thời gian hồi chiêu dựa trên chỉ số Haste của Yasuo
        this.cooldownTime =
            CooldownCalculator.GetCooldown(this.yasuoSkill.yasuoSkillData[0].cooldown, this.yasuoStats.haste);

        // Kiểm tra nếu đang trong thời gian hồi chiêu
        if (this.isCooldown && (!Input.GetMouseButtonDown(0) && !Input.GetMouseButtonDown(1)))
        {
            this.animator.SetInteger(nameof(AnimationParams.currentSkill), 3);
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
        AudioManager.Instance.PlaySFXClip(nameof(AudioNameEnum.YasuoNormalAttack));
        this.yasuoSkill.lastSkillIndex = 0;
        this.animator.SetInteger(nameof(AnimationParams.currentSkill), 0);
        this.isCooldown = true;
        this.cooldownTimer = this.cooldownTime;
    }
}