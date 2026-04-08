using VyesBase.Core.Architecture.Interfaces;

namespace VyesBase.Systems.Level
{
    public interface ILevelService : IService
    {
        int MaxLevel { get; }
        float GetExpRequiredForLevel(int level);
        bool CanLevelUp(int currentLevel, float currentExp);
    }
}