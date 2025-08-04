using UnityEngine;

public class EnemyAttacking : VyesBehaviour
{
    [SerializeField] private MainEnemyStats stats;
    [SerializeField] private Animator animator;
    private float attackTimer = 0f;
    private const string BulletName = "Bullet";

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
        bool isOnScreen = screenPoint.x is >= 0 and <= 1 &&
                          screenPoint.y is >= 0 and <= 1 &&
                          screenPoint.z > 0;
        return isOnScreen;
    }

    //Spawn bullet mỗi khi attack
    private void Attack()
    {
        Transform newBullet =
            BulletSpawner.Instance.Spawn(BulletName, this.transform.position, this.GetRandomRotation());
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
}