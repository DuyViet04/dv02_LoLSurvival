using System;
using UnityEngine;

public class Flying : MonoBehaviour
{
    private void Update()
    {
        this.transform.parent.Translate(Vector3.forward * 5 * Time.deltaTime);
    }
}