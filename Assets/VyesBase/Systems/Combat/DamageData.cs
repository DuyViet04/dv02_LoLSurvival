namespace VyesBase.Systems.Combat
{
    public struct DamageData
    {
        public readonly float Amount;
        public IDamageSource Source;
        public DamageType Type;
        public bool IsCritical;

        public DamageData(float amount, IDamageSource source, DamageType type = DamageType.Physical,
            bool isCritical = false)
        {
            Amount = amount;
            Source = source;
            Type = type;
            IsCritical = isCritical;
        }
    }
}