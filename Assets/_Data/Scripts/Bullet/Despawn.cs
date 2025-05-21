using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    private float lifeTime = 10f;
    private float timer = 0f;

    private void Update()
    {
        this.timer += Time.deltaTime;
        if (this.timer < this.lifeTime) return;
        this.timer = 0f;
        BulletSpawner.Instance.Despawn(this.transform.parent);
    }
}