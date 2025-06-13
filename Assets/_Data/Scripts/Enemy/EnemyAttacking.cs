using UnityEngine;

public class EnemyAttacking : VyesBehaviour
{
    [SerializeField] private MainEnemyStats stats;
    [SerializeField] private Animator animator;
    private float attackTimer = 0f;

    private void Update()
    {
        bool isOnScreen = this.IsOnScreen();
        if (!isOnScreen) return;

        this.attackTimer += Time.deltaTime; //Tính thời gian giữa 2 lần bắn
        if (this.attackTimer < this.GetAttackDelay(this.stats.attackSpeed)) return;
        this.attackTimer = 0f;
        this.Attack();
    }

    bool IsOnScreen()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(this.transform.parent.position);
        bool isOnScreen = screenPoint.x >= 0 && screenPoint.x <= 1 &&
                          screenPoint.y >= 0 && screenPoint.y <= 1 &&
                          screenPoint.z > 0;
        return isOnScreen;
    }

    //Spawn bullet mỗi khi attack
    private void Attack()
    {
        Transform newBullet =
            BulletSpawner.Instance.Spawn("Bullet", this.transform.position, this.transform.parent.rotation);
        newBullet.GetComponentInChildren<BulletDealingDamage>().SetAttackDamage(this.stats.attackData.baseDamage);
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
        if (this.stats != null) return;
        this.stats = SOManager.Instance.GetEnemyStatsByType(this.transform.parent.name);
        Debug.LogWarning(this.transform.name + ": LoadStats", this.gameObject);
    }

    void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = this.transform.parent.GetComponentInChildren<Animator>();
        Debug.LogWarning(this.transform.name + ": LoadAnimator", this.gameObject);
    }
}