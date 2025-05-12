using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MeleeEnemyStats", menuName = "Stats/MeleeEnemy")]
public class MeleeEnemyStats : MainEnemyStats
{
    private void Reset()
    {
        this.enemyName = "MeleeEnemy";
        this.health = 477;
        this.damage = 80;
        this.moveSpeed = 1.5f;
        this.armor = 12;
    }
}