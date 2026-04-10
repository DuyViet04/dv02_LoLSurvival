using _Data.Refactor.Models.SOs.Skills.Yasuo;

namespace _Data.Refactor.Models.Runtimes.Skills.Yasuo
{
    public class NormalAttackSoRuntime : BasePlayerSkillSoRuntime
    {
        private NormalAttackSo normalAttackSo;
        
        public NormalAttackSoRuntime(NormalAttackSo baseSo) : base(baseSo)
        {
            normalAttackSo = baseSo;
        }
    }
}