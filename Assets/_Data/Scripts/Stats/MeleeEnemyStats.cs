using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MeleeEnemyStats", menuName = "Stats/MeleeEnemy")]
public class MeleeEnemyStats : MainStats
{
    private void Awake()
    {
        this.name = "MeleeEnemy";
        this.hp = 10;
        this.damage = 3;
        this.moveSpeed = 3;
        this.attackSpeed = 1;
    }
}