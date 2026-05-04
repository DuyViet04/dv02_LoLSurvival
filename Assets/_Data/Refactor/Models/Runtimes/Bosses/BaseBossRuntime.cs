using System.Collections.Generic;
using _Data.Refactor.Models.Runtimes.Skills;
using _Data.Refactor.Models.SOs.Bosses;
using Base.Core.Architecture.Model;
using Base.Systems.Combat;

namespace _Data.Refactor.Models.Runtimes.Bosses
{
    public class BaseBossRuntime : BaseRuntime
    {
        public AttackData AttackData { get; private set; }
        public List<BasePlayerSkillRuntime> SkillsRuntime { get; private set; }

        public BaseBossRuntime(BaseBossSo baseSo) : base(baseSo)
        {
            AttackData = new AttackData(baseSo.attackData);
            SkillsRuntime = new List<BasePlayerSkillRuntime>();
            foreach (var skillSo in baseSo.skills)
            {
                SkillsRuntime.Add(new BasePlayerSkillRuntime(skillSo));
            }
            Init();
        }

        protected override void AddData()
        {
            data.Add(DefensiveData);
            data.Add(OffensiveData);
            data.Add(UtilityData);
        }
    }
}