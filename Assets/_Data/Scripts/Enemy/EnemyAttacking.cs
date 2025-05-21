using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyAttacking : MonoBehaviour
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
        this.attackTimer += Time.deltaTime;
        if (this.attackTimer < this.GetAttackDelay(this.stats.attackSpeed)) return;
        this.attackTimer = 0f;
        this.Attack();
    }

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

    Quaternion GetRandomRotation()
    {
        Quaternion rot = this.transform.rotation;
        float newRotY = Random.Range(rot.y - 10, rot.y + 10);
        Quaternion newRot = Quaternion.Euler(0, newRotY, 0);
        return newRot;
    }
}