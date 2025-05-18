using System;
using UnityEngine;

public class Collecting : MonoBehaviour
{
    [SerializeField] private YasuoStats baseYasuoStats;
    [SerializeField] private CapsuleCollider pickUpCollider;
    private YasuoStats yasuoStats;

    private void Awake()
    {
        this.yasuoStats = Instantiate(this.baseYasuoStats);
    }

    private void FixedUpdate()
    {
        this.pickUpCollider.radius = this.yasuoStats.pickUpRange;
    }

    private void OnTriggerEnter(Collider other)
    {
        Transform parent = other.transform.parent;

        if (parent != null && parent.CompareTag("Item"))
        {
            other.GetComponent<ExpBehaviour>().StartMove();
        }
    }
}