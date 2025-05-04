using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "YasuoStats", menuName = "Stats/Yasuo")]

public class YasuoStats : MainCharacterStats
{
    private void Awake()
    {
        this.characterName = "Yasuo";
        this.health = 100f;
        this.moveSpeed = 7f;
        this.attackDamage = 10f;
        this.attackSpeed = 1f;
    }
}
