using _Data.Refactor.Models.SOs.Enemies.Data;
using Base.Core.Architecture.Model;
using Base.Systems.Combat;
using UnityEngine;

namespace _Data.Refactor.Models.SOs.Enemies
{
    [CreateAssetMenu(fileName = "BaseEnemySo", menuName = "SOs/Enemy/BaseEnemySo")]
    public class BaseEnemySo : BaseSo
    {
        public EnemyData enemyData;
        public AttackData attackData;
    }
}