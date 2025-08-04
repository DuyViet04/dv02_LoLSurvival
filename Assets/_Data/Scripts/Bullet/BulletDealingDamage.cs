using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class BulletDealingDamage : DealingDamage
{
    public void SetAttackDamage(float damage)
    {
        this.attackDamage = damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        Transform parent = other.transform.parent;
        if (parent != null && parent.CompareTag(nameof(TagEnum.Player)))
        {
            parent.GetComponentInChildren<PlayerTakingDamage>().TakeDamage(this.attackDamage);
            BulletSpawner.Instance.Despawn(this.transform.parent);
        }
    }
}