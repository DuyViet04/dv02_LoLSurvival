using _Data.Refactor.Enums.Enemies;
using VyesBase.Core.Architecture.Model;

namespace _Data.Refactor.Models.SOs.Enemies
{
    public abstract class BaseEnemySo : BaseSo
    {
        public EnemyType type;
        public float health;
        public AttackData attackData;
        public float attackSpeed;
        public float moveSpeed;
        public float armor;
        public float magicResistance;
        public float expValue;
        public float goldValue;
        public float csValue;
        public float spawnDelay;
        public float spawnCount;
    }
}