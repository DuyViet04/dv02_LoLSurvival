using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class BulletDealingDamage : DealingDamage
{
    [SerializeField] private SphereCollider sphereCollider;

    public void SetAttackDamage(float damage)
    {
        this.attackDamage = damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        Transform parent = other.transform.parent;
        if (parent != null && parent.CompareTag("Player"))
        {
            parent.GetComponentInChildren<PlayerTakingDamage>().TakeDamage(this.attackDamage);
            BulletSpawner.Instance.Despawn(this.transform.parent);
        }
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
    }

    void LoadSphereCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.2f;
        Debug.LogWarning(this.transform.name + ": LoadSphereCollider", this.gameObject);
    }
}