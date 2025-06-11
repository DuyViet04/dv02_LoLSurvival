using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Skill1Attack : VyesBehaviour
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

        this.cooldownTime =
            CooldownCalculator.GetCooldown(this.yasuoSkill.yasuoSkillData[1].cooldown, this.yasuoStats.haste);

        if (this.isCooldown)
        {
            this.cooldownTimer -= Time.deltaTime;
            if (this.cooldownTimer <= 0)
            {
                this.cooldownTimer = 0;
                this.isCooldown = false;
                this.animator.SetInteger("currentSkill", 3);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            this.Attack();
        }

        this.UICooldown();
    }

    void Attack()
    {
        if (this.isCooldown) return;
        AudioManager.Instance.PlaySFXClip("YasuoSkill1");
        this.yasuoSkill.lastSkillIndex = 1;
        this.animator.SetInteger("currentSkill", 1);
        Quaternion rotation = Quaternion.Euler(-90, this.transform.parent.eulerAngles.y, 0);
        Instantiate(this.prefab, this.transform.parent.position, rotation);
        this.isCooldown = true;
        this.cooldownTimer = this.cooldownTime;
    }

    public AttackData GetAttackData()
    {
        AttackData skill1 = this.yasuoSkill.yasuoSkillData[1];
        return skill1;
    }

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

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadYasuoStats();
        this.LoadYasuoSkill();
        this.LoadAnimator();
        this.LoadCooldownImage();
        this.LoadCooldownText();
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

    void LoadCooldownImage()
    {
        if (this.cooldownImage != null) return;
        Transform skill1 = GameObject.Find("Skill1").transform;
        this.cooldownImage = skill1.Find("CD").GetComponent<Image>();
        Debug.LogWarning(this.transform.name + ": LoadCooldownImage", this.gameObject);
    }

    void LoadCooldownText()
    {
        if (this.cooldownText != null) return;
        Transform skill1 = GameObject.Find("Skill1").transform;
        this.cooldownText = skill1.GetComponentInChildren<TMP_Text>();
        Debug.LogWarning(this.transform.name + ": LoadCooldownText", this.gameObject);
    }
}