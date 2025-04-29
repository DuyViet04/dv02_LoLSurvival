using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLooking : LookingTarget
{
    private void Update()
    {
        this.LookAtTarget(this.transform.parent, this.target.transform);
    }
}