using VyesBase.Core.Architecture.Model;

namespace VyesBase.Systems.Skills
{
    public abstract class BaseSkillSoRuntime : BaseSoRuntime
    {
        protected BaseSkillSo baseSkillSo;
        protected float currentCooldown;
        public float CurrentCooldown => currentCooldown;
        public float CooldownPercentage => baseSkillSo.cooldown > 0 ? currentCooldown / baseSkillSo.cooldown : 0;
        public bool IsOnCooldown => currentCooldown > 0;

        protected BaseSkillSoRuntime(BaseSkillSo baseSo) : base(baseSo)
        {
            this.baseSkillSo = baseSo;
            this.currentCooldown = 0f;
        }

        public virtual void UpdateCooldown(float deltaTime)
        {
            if (currentCooldown > 0)
            {
                currentCooldown -= deltaTime;
                if (currentCooldown < 0) currentCooldown = 0;
            }
        }

        public virtual bool TryUse()
        {
            if (IsOnCooldown) return false;

            currentCooldown = baseSkillSo.cooldown;
            return true;
        }
    }
}
