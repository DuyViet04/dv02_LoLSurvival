using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class Collecting : VyesBehaviour
{
    [SerializeField] private YasuoStats yasuoStats;
    [SerializeField] private CapsuleCollider pickUpCollider;

    private void FixedUpdate()
    {
        this.pickUpCollider.radius = this.yasuoStats.pickUpRange;
    }

    // Khi có collider đi vào vùng pick up, sẽ gọi hàm StartMove của ExpBehaviour
    private void OnTriggerEnter(Collider other)
    {
        Transform parent = other.transform.parent;

        if (parent != null && parent.CompareTag("Item"))
        {
            other.GetComponent<ExpBehaviour>().StartMove();
        }
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadYasuoStats();
        this.LoadPickUpCollider();
    }

    void LoadYasuoStats()
    {
        if (this.yasuoStats != null) return;
        this.yasuoStats = SOManager.Instance.GetYasuoStats();
        Debug.LogWarning(this.transform.name + ": LoadYasuoStats", this.gameObject);
    }

    void LoadPickUpCollider()
    {
        if (this.pickUpCollider != null) return;
        this.pickUpCollider = this.GetComponent<CapsuleCollider>();
        Debug.LogWarning(this.transform.name + ": LoadPickUpCollider", this.pickUpCollider);
    }
}