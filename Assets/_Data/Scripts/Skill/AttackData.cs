using UnityEngine.Serialization;

[System.Serializable]
public class AttackData
{
    public AttackType attackType;
    public DamageType damageType;
    public float baseDamage;
    public float bonusAD;
    public float bonusAP;
    public bool isCritical;
    public float cooldown;

    public float GetDamage(float attackDamage, float abilityPower)
    {
        return baseDamage + (bonusAD / 100 * attackDamage) + (bonusAP / 100 * abilityPower);
    }
}