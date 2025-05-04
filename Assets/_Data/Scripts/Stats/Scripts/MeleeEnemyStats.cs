using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MeleeEnemyStats", menuName = "Stats/MeleeEnemy")]
public class MeleeEnemyStats : MainEnemyStats
{
    private void Awake()
    {
        this.enemyName = "MeleeEnemy";
        this.health = 10;
        this.damage = 3;
        this.moveSpeed = 3;
    }
}