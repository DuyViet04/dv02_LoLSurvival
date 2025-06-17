public class CooldownCalculator
{
    // Tính toán thời gian hồi chiêu dựa trên thời gian hồi chiêu cơ bản và tốc độ hồi chiêu
    public static float GetCooldown(float baseCooldown, float haste)
    {
        return baseCooldown / (1 + haste / 100);
    }
}