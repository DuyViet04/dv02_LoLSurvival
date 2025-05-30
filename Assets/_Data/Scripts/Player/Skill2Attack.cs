using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Skill2Attack : VyesBehaviour
{
    [SerializeField] private YasuoStats yasuoStats;
    [SerializeField] private YasuoSkill yasuoSkill;
    [SerializeField] private Animator animator;
    [SerializeField] private Image cooldownImage;
    [SerializeField] private TMP_Text cooldownText;
    private Vector3 dashDirection;
    private float cooldownTime;
    private float dashDuration = 0.5f;
    private float cooldownTimer;
    private float dashTimer;
    private bool isCooldown = false;
    private bool isDash = false;

    private void Update()
    {
        if (Time.timeScale == 0) return;

        this.cooldownTime = CooldownCalculator.GetCooldown(this.yasuoSkill.yasuoSkillData[2].cooldown,
            this.yasuoStats.haste);

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

        if (this.isDash)
        {
            this.dashTimer -= Time.deltaTime;
            this.transform.parent.Translate(this.dashDirection * 10 * Time.deltaTime);

            if (this.dashTimer <= 0f)
            {
                this.isDash = false;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            this.Attack();
        }

        this.UICooldown();
    }

    void Attack()
    {
        if (this.isCooldown) return;
        this.yasuoSkill.lastSkillIndex = 2;

        this.isDash = true;
        this.dashTimer = this.dashDuration;
        this.dashDirection = Vector3.forward;

        this.animator.SetInteger("currentSkill", 2);
        this.isCooldown = true;
        this.cooldownTimer = this.cooldownTime;
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
        string[] guids = AssetDatabase.FindAssets("t:YasuoStats", new[] { "Assets/_Data/Scripts/Stat/Character/SO" });
        string path = AssetDatabase.GUIDToAssetPath(guids[0]);
        this.yasuoStats = AssetDatabase.LoadAssetAtPath<YasuoStats>(path);
        Debug.LogWarning(this.transform.name + ": LoadYasuoStats", this.gameObject);
    }

    void LoadYasuoSkill()
    {
        if (this.yasuoSkill != null) return;
        string[] guids = AssetDatabase.FindAssets("t:YasuoSkill", new[] { "Assets/_Data/Scripts/Player/Attack/SO" });
        string path = AssetDatabase.GUIDToAssetPath(guids[0]);
        this.yasuoSkill = AssetDatabase.LoadAssetAtPath<YasuoSkill>(path);
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
        Transform skill2 = GameObject.Find("Skill2").transform;
        this.cooldownImage = skill2.Find("CD").GetComponent<Image>();
        Debug.LogWarning(this.transform.name + ": LoadCooldownImage", this.gameObject);
    }

    void LoadCooldownText()
    {
        if (this.cooldownText != null) return;
        Transform skill2 = GameObject.Find("Skill2").transform;
        this.cooldownText = skill2.GetComponentInChildren<TMP_Text>();
        Debug.LogWarning(this.transform.name + ": LoadCooldownText", this.gameObject);
    }
}