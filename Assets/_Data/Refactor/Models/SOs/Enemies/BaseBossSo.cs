using System.Collections.Generic;
using Base.Systems.Skill;
using UnityEngine;

namespace _Data.Refactor.Models.SOs.Enemies
{
    [CreateAssetMenu(fileName = "BaseBossSo", menuName = "SOs/Enemy/BaseBossSo")]
    public class BaseBossSo : BaseEnemySo
    {
        public List<BaseSkillSo> skills;
    }
}