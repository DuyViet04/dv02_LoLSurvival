using VyesBase.Core.Architecture.Model;

namespace VyesBase.Systems.Skills
{
    public abstract class BaseSkillSo : BaseSo
    {
        public float baseDamage;
        public DamageType damageType;
        public bool canCrit;
        public float cooldown;
    }
}
