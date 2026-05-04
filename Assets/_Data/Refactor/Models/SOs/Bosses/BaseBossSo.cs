using System.Collections.Generic;
using _Data.Refactor.Models.SOs.Bosses.Data;
using Base.Core.Architecture.Model;
using Base.Systems.Combat;
using Base.Systems.Skill;
using UnityEngine;

namespace _Data.Refactor.Models.SOs.Bosses
{
    [CreateAssetMenu(fileName = "BaseBossSo", menuName = "SOs/Boss/BaseBossSo")]
    public class BaseBossSo : BaseSo
    {
        public BossData bossData;
        public AttackData attackData;
        public List<BaseSkillSo> skills;
    }
}