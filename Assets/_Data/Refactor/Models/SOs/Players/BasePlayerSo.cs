using System.Collections.Generic;
using _Data.Refactor.Models.Runtimes.Players;
using UnityEngine;
using VyesBase.Core.Architecture.Model;
using VyesBase.Systems.Skills;

namespace _Data.Refactor.Models.SOs.Players
{
    public abstract class BasePlayerSo : BaseSo
    {
        [Header("Main Stats")] public string characterName;
        public float health;
        public float healthRegen;
        public float attackDamage;
        public float abilityPower;
        public float armor;
        public float magicResistance;
        public float moveSpeed;
        public float criticalChance;
        public float criticalDamage;
        public float armorPenetration;
        public float magicPenetration;
        public float lifeSteal;
        public float omnivamp;
        public float haste;
        public float healingPower;
        [Header("Secondary Stats")] public float pickUpRange;
        public float expMultiplier;
        [Header("Skills")] public List<BaseSkillSo> skills;

        public override BaseSoRuntime CreateRuntime()
        {
            return new BasePlayerSoRuntime(this);
        }
    }
}