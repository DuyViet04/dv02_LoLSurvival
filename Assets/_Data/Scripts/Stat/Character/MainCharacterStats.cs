using UnityEngine;

public class MainCharacterStats : ScriptableObject
{
    [Header("Main Stats")]
    public string characterName;
    public float health;
    public float healthRegen;
    public float attackDamage;
    public float abilityPower;
    public float armor;
    public float magicResistance;
    public float moveSpeed;
    public float criticalChance;
    public float criticalDamage;
    public float armorPenetration;
    public float magicPenetration;
    public float lifeSteal;
    public float omnivamp;
    public float haste;
    public float healingPower;
    [Header("Secondary Stats")]
    public float pickUpRange;
    public float expMultiplier;
}
