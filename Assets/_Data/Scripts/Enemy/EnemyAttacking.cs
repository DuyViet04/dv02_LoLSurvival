using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyAttacking : VyesBehaviour
{
    [SerializeField] private MainEnemyStats stats;
    [SerializeField] private SOManager soManager;
    [SerializeField] private Animator animator;
    private float attackTimer = 0f;

    private void Awake()
    {
        this.stats = this.soManager.GetStatsByType(this.transform.parent.name);
    }

    private void Update()
    {
        this.attackTimer += Time.deltaTime; //Tính thời gian giữa 2 lần bắn
        if (this.attackTimer < this.GetAttackDelay(this.stats.attackSpeed)) return;
        this.attackTimer = 0f;
        this.Attack();
    }

    //Spawn bullet mỗi khi attack
    private void Attack()
    {
        Transform newBullet =
            BulletSpawner.Instance.Spawn("Bullet", this.transform.position, this.transform.parent.rotation);
        newBullet.GetComponentInChildren<BulletDealingDamage>().SetAttackDamage(this.stats.damage);
        this.animator.speed = this.GetAnimationSpeed(this.stats.attackSpeed);
    }

    float GetAttackDelay(float attackSpeed)
    {
        return 1 / attackSpeed;
    }

    float GetAnimationSpeed(float attackSpeed)
    {
        return 1 * attackSpeed;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadStats();
        this.LoadAnimator();
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

    void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = this.transform.parent.GetComponentInChildren<Animator>();
        Debug.LogWarning(this.transform.name + ": LoadAnimator", this.gameObject);
    }
}