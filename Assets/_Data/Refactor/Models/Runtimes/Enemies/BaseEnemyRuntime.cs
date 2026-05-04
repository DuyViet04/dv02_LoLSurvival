using _Data.Refactor.Models.SOs.Enemies;
using _Data.Refactor.Models.SOs.Enemies.Data;
using Base.Core.Architecture.Model;
using Base.Systems.Combat;

namespace _Data.Refactor.Models.Runtimes.Enemies
{
    public class BaseEnemyRuntime : BaseRuntime
    {
        public EnemyData EnemyData { get; private set; }
        public AttackData AttackData { get; private set; }

        public BaseEnemyRuntime(BaseEnemySo baseSo) : base(baseSo)
        {
            EnemyData = new EnemyData(baseSo.enemyData);
            AttackData = new AttackData(baseSo.attackData);
            Init();
        }

        protected override void AddData()
        {
            data.Add(DefensiveData);
            data.Add(OffensiveData);
            data.Add(UtilityData);
            data.Add(EnemyData);
        }
    }
}