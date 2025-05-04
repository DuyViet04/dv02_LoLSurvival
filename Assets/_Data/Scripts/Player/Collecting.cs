using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Collecting : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Transform parent = other.transform.parent;

        if (parent != null && parent.CompareTag("Item"))
        {
            other.GetComponent<PickedUp>().PickUp();
            Debug.Log(other.transform.name);
        }
    }
}