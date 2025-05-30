public class CooldownCalculator
{
    public static float GetCooldown(float baseCooldown, float haste)
    {
        return baseCooldown / (1 + haste / 100);
    }
}