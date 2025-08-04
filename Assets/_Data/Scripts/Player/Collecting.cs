using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class Collecting : MonoBehaviour
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
}