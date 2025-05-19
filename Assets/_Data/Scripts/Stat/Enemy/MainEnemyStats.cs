using UnityEngine;

public abstract class MainEnemyStats : ScriptableObject
{
    public EnemyType type;
    public float health;
    public float damage;
    public float attackSpeed;
    public float moveSpeed;
    public float armor;
    public float magicResistance;
    public float expValue;
    public float goldValue;
    public float spawnDelay;
    public int spawnCount;
    
    public abstract MainEnemyStats GetBaseStats();
    public abstract void ResetStats();
}