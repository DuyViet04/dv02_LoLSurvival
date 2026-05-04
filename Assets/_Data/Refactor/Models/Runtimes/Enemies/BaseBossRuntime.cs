using System.Collections.Generic;
using _Data.Refactor.Models.Runtimes.Skills;
using _Data.Refactor.Models.SOs.Enemies;

namespace _Data.Refactor.Models.Runtimes.Enemies
{
    public class BaseBossRuntime : BaseEnemyRuntime
    {
        public List<BasePlayerSkillRuntime> SkillsRuntime { get; private set; }

        public BaseBossRuntime(BaseBossSo baseSo) : base(baseSo)
        {
            SkillsRuntime = new List<BasePlayerSkillRuntime>();
            foreach (var skillSo in baseSo.skills)
            {
                SkillsRuntime.Add(new BasePlayerSkillRuntime(skillSo));
            }
        }
    }
}