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
        this.moveSpeed = 2;
        this.armor = 12;
    }
}