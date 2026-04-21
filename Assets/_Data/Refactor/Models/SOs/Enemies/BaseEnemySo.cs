using _Data.Refactor.Models.SOs.Enemies.Data;
using Base.Core.Architecture.Model;
using Base.Systems.Combat;

namespace _Data.Refactor.Models.SOs.Enemies
{
    public abstract class BaseEnemySo : BaseSo
    {
        public EnemyData enemyData;
        public AttackData attackData;
    }
}