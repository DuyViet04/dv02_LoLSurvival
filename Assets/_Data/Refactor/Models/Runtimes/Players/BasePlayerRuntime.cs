using _Data.Refactor.Models.SOs.Players;
using _Data.Refactor.Models.SOs.Players.Data;
using Base.Core.Architecture.Model;

namespace _Data.Refactor.Models.Runtimes.Players
{
    public class BasePlayerRuntime : BaseRuntime
    {
        public PlayerData PlayerData { get; private set; }

        public BasePlayerRuntime(BasePlayerSo baseSo) : base(baseSo)
        {
            PlayerData = new PlayerData(baseSo.playerData);
        }
    }
}