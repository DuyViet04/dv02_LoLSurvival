using System.Collections.Generic;
using _Data.Refactor.Models.SOs.Players.Data;
using Base.Core.Architecture.Model;
using Base.Systems.Level;
using Base.Systems.Skill;
using UnityEngine;

namespace _Data.Refactor.Models.SOs.Players
{
    [CreateAssetMenu(fileName = "BasePlayerSo", menuName = "SOs/Player/BasePlayerSo")]
    public class BasePlayerSo : BaseSo
    {
        public PlayerData playerData;
        public LevelData levelData;
        public List<BaseSkillSo> skills;
    }
}