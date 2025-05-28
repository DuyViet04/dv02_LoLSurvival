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
    private float cooldownTimer;
    private bool isCooldown = false;

    private void Update()
    {
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
        this.animator.SetInteger("currentSkill", 1);
        this.isCooldown = true;
        this.cooldownTimer = this.yasuoSkill.yasuoSkillData[1].cooldown;
    }

    void UICooldown()
    {
        if (this.cooldownTimer <= 0)
        {
            this.cooldownText.text = "";
        }

        this.cooldownText.text = this.cooldownTimer.ToString("0");
        this.cooldownImage.fillAmount = this.cooldownTimer / this.yasuoSkill.yasuoSkillData[1].cooldown;
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