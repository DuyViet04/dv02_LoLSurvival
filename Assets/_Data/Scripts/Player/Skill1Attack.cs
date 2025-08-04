using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Skill1Attack : MonoBehaviour
{
    [SerializeField] private YasuoStats yasuoStats;
    [SerializeField] private YasuoSkill yasuoSkill;
    [SerializeField] private Animator animator;
    [SerializeField] private Image cooldownImage;
    [SerializeField] private TMP_Text cooldownText;
    [SerializeField] private GameObject prefab;
    private float cooldownTime;
    private float cooldownTimer;
    private bool isCooldown = false;

    private void Update()
    {
        if (Time.timeScale == 0) return;

        // Tính thời gian hồi chiêu dựa trên chỉ số Haste của Yasuo
        this.cooldownTime =
            CooldownCalculator.GetCooldown(this.yasuoSkill.yasuoSkillData[1].cooldown, this.yasuoStats.haste);

        // Kiểm tra nếu đang trong thời gian hồi chiêu
        if (this.isCooldown)
        {
            this.cooldownTimer -= Time.deltaTime;
            if (this.cooldownTimer <= 0)
            {
                this.cooldownTimer = 0;
                this.isCooldown = false;
                this.animator.SetInteger(nameof(AnimationParams.currentSkill), 3);
            }
        }

        // Nếu không đang trong thời gian hồi chiêu và người chơi nhấn nút tấn công
        if (Input.GetMouseButtonDown(0))
        {
            this.Attack();
        }

        this.UICooldown(); // Cập nhật giao diện hồi chiêu
    }

    void Attack()
    {
        if (this.isCooldown) return;
        AudioManager.Instance.PlaySFXClip(nameof(AudioNameEnum.YasuoSkill1));
        this.yasuoSkill.lastSkillIndex = 1; // Lưu chỉ số kỹ năng cuối cùng đã sử dụng
        this.animator.SetInteger(nameof(AnimationParams.currentSkill), 1);
        Quaternion rotation = Quaternion.Euler(-90, this.transform.parent.eulerAngles.y, 0); 
        Instantiate(this.prefab, this.transform.parent.position, rotation);
        this.isCooldown = true;
        this.cooldownTimer = this.cooldownTime;
    }

    // Lấy AttackData từ YasuoSkill dựa trên chỉ số kỹ năng 1
    public AttackData GetAttackData()
    {
        AttackData skill1 = this.yasuoSkill.yasuoSkillData[1];
        return skill1;
    }

    // Cập nhật giao diện hồi chiêu
    void UICooldown()
    {
        this.cooldownText.text = this.cooldownTimer.ToString("0.0");
        if (this.cooldownTimer <= 0)
        {
            this.cooldownText.text = "";
        }

        this.cooldownImage.fillAmount = this.cooldownTimer / this.cooldownTime;
        if (this.cooldownTimer <= 0)
        {
            this.cooldownImage.fillAmount = 0;
        }
    }
}