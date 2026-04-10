using _Data.Refactor.Models.SOs.Skills.Yasuo;

namespace _Data.Refactor.Models.Runtimes.Skills.Yasuo
{
    public class Skill1SoRuntime : BasePlayerSkillSoRuntime
    {
        private Skill1So skill1So;

        public Skill1SoRuntime(Skill1So baseSo) : base(baseSo)
        {
            skill1So = baseSo;
        }
    }
}