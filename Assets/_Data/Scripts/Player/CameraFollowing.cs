using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void Update()
    {
        Follow(this.target);
    }

    void Follow(Transform target)
    {
        Vector3 targetPos = new Vector3(target.position.x, 10, target.position.z);
        Vector3 pos = Vector3.Lerp(this.transform.position, targetPos, 1f);
        this.transform.position = pos;
    }
}