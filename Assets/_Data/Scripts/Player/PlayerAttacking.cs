using UnityEngine;

public class PlayerAttacking : MonoBehaviour
{
    [SerializeField] private FindClosestEnemy findClosest;
    [SerializeField] private YasuoStats stats;
    [SerializeField] private Animator animator;
    private float attackTimer = 0f;

    private void Update()
    {
        float dis = this.findClosest.GetDistanceToTarget();
        if (dis > 5)
        {
            this.animator.ResetTrigger("isAttack");
            return;
        }

        this.attackTimer += Time.deltaTime;
        if (this.attackTimer < this.GetAttackDelay(this.stats.attackSpeed)) return;
        this.attackTimer = 0f;
        this.Attack();
    }

    void Attack()
    {
        this.animator.SetTrigger("isAttack");
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
}