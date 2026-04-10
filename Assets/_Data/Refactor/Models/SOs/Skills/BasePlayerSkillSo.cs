using _Data.Refactor.Enums.Skills;
using _Data.Refactor.Models.Runtimes.Skills;
using VyesBase.Core.Architecture.Model;
using VyesBase.Systems.Skills;

namespace _Data.Refactor.Models.SOs.Skills
{
    public abstract class BasePlayerSkillSo : BaseSkillSo
    {
        public SkillType skillType;
        public float bonusAd;
        public float bonusAp;

        public override BaseSoRuntime CreateRuntime()
        {
            return new BasePlayerSkillSoRuntime(this);
        }
    }
}