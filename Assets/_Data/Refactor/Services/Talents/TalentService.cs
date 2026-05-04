using System;
using System.Collections.Generic;
using _Data.Refactor.Managers;
using _Data.Refactor.Models.SOs.Talents;
using _Data.Refactor.Models.Persistences;
using _Data.Refactor.Services.SaveLoad;
using Base.Core.Singleton;
using Base.Systems.Stat;
using UnityEngine;

namespace _Data.Refactor.Services.Talents
{
    [DefaultExecutionOrder(-90)]
    public class TalentService : VyesPersistentSingleton<TalentService>
    {
        private int csPoints;
        private readonly Dictionary<string, int> talentLevels = new Dictionary<string, int>();

        public int CsPoints => csPoints;
        public TalentGroupSo TalentGroup => SoManager.Ins.TalentGroupSo;

        public event Action OnDataChanged;

        public int GetTalentLevel(string talentId)
        {
            if (!talentLevels.ContainsKey(talentId)) return 0;
            return talentLevels[talentId];
        }

        public void AddCsPoints(int amount)
        {
            csPoints += amount;
            OnDataChanged?.Invoke();
            SaveService.Ins.SaveGame();
        }

        public bool CanUpgrade(TalentSo talent)
        {
            int currentLevel = GetTalentLevel(talent.talentId);
            if (currentLevel >= talent.maxLevel) return false;

            return csPoints >= talent.GetCost(currentLevel);
        }

        public void UpgradeTalent(TalentSo talent)
        {
            if (!CanUpgrade(talent)) return;

            int currentLevel = GetTalentLevel(talent.talentId);
            csPoints -= talent.GetCost(currentLevel);
            talentLevels[talent.talentId] = currentLevel + 1;

            OnDataChanged?.Invoke();
            SaveService.Ins.SaveGame();
        }

        public void ApplyTalentsToRuntime(Base.Core.Architecture.Model.BaseRuntime runtime)
        {
            foreach (var talent in TalentGroup.talents)
            {
                int level = GetTalentLevel(talent.talentId);
                if (level <= 0) continue;

                float value = talent.GetEffectValue(level);
                var modifier = new StatModifier(value, talent.modifierType, this);
                runtime.Stats[talent.statType].AddModifier(modifier);
            }
        }

        #region Persistence

        public TalentPersistenceData GetPersistenceData()
        {
            var data = new TalentPersistenceData
            {
                csPoints = this.csPoints
            };

            foreach (var kvp in talentLevels)
            {
                data.talentLevels.Add(new TalentLevelData
                {
                    talentId = kvp.Key,
                    level = kvp.Value
                });
            }

            return data;
        }

        public void LoadFromPersistenceData(TalentPersistenceData data)
        {
            this.csPoints = data.csPoints;
            this.talentLevels.Clear();
            foreach (var talentData in data.talentLevels)
            {
                this.talentLevels[talentData.talentId] = talentData.level;
            }

            OnDataChanged?.Invoke();
        }

        #endregion
    }
}