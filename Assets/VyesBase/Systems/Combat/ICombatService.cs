using VyesBase.Core.Architecture.Interfaces;

namespace VyesBase.Systems.Combat
{
    public interface ICombatService : IService
    {
        float CalculateFinalDamage(DamageData rawDamage, BaseHealth target);
    }
}