using System;
using UnityEngine;

public abstract class MainBossStats : MainCharacterStats
{
     public BossType bossType;

     public abstract MainBossStats GetBaseStats();
     public abstract void ResetStats();
}