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

    // Kiểm tra xem Enemy có đang ở trên màn hình hay không
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
            BulletSpawner.Instance.Spawn("Bullet", this.transform.position, this.GetRandomRotation());
        newBullet.GetComponentInChildren<BulletDealingDamage>().SetAttackDamage(this.stats.attackData.baseDamage);
        this.animator.speed = this.GetAnimationSpeed(this.stats.attackSpeed);
    }

    Quaternion GetRandomRotation()
    {
        Vector3 forward = this.transform.parent.forward;
        float angle = Random.Range(-30f, 30f);
        Vector3 rotatedDirection = Quaternion.Euler(0f, angle, 0f) * forward;
        return Quaternion.LookRotation(rotatedDirection);
    }


    //Tính toán thời gian giữa 2 lần bắn
    float GetAttackDelay(float attackSpeed)
    {
        return 1 / attackSpeed;
    }


    //Tính toán tốc độ anim dựa trên tốc độ tấn công
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