using _Data.Refactor.Models.SOs.Players;
using _Data.Refactor.Models.SOs.Players.Data;
using Base.Core.Architecture.Model;
using Base.Systems.Level;

namespace _Data.Refactor.Models.Runtimes.Players
{
    public class BasePlayerRuntime : BaseRuntime
    {
        public PlayerData PlayerData { get; private set; }
        public LevelData LevelData { get; private set; }

        public BasePlayerRuntime(BasePlayerSo baseSo) : base(baseSo)
        {
            PlayerData = new PlayerData(baseSo.playerData);
            LevelData = new LevelData(baseSo.levelData);
            Init();
        }

        protected override void AddData()
        {
            data.Add(DefensiveData);
            data.Add(OffensiveData);
            data.Add(UtilityData);
            data.Add(PlayerData);
            data.Add(LevelData);
        }
    }
}