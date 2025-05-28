using UnityEngine;

public abstract class MainEnemyStats : ScriptableObject
{
    public EnemyType type;
    public float health;
    public AttackData attackData;
    public float attackSpeed;
    public float moveSpeed;
    public float armor;
    public float magicResistance;
    public float expValue;
    public float goldValue;
    public float csValue;
    public float spawnDelay;
    public float spawnCount;

    public abstract MainEnemyStats GetBaseStats();
    public abstract void ResetStats();
}