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
        this.damage = 12;
        this.moveSpeed = 1.5f;
        this.armor = 16;
        this.expValue = 61.75f;
    }

    public void ResetStats()
    {
        this.enemyName = "MeleeEnemy";
        this.health = 477;
        this.damage = 12;
        this.moveSpeed = 1.5f;
        this.armor = 16;
        this.expValue = 61.75f;
    }
}