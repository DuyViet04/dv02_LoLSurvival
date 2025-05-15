using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecting : MonoBehaviour
{
    [SerializeField] private YasuoStats stats;
    [SerializeField] private CapsuleCollider pickUpCollider;

    private void FixedUpdate()
    {
        this.pickUpCollider.radius = this.stats.pickUpRange;
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