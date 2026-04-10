using _Data.Refactor.Models.SOs.Skills.Yasuo;

namespace _Data.Refactor.Models.Runtimes.Skills.Yasuo
{
    public class Skill2SoRuntime : BasePlayerSkillSoRuntime
    {
        private Skill2So skill2So;

        public Skill2SoRuntime(Skill2So baseSo) : base(baseSo)
        {
            skill2So = baseSo;
        }
    }
}