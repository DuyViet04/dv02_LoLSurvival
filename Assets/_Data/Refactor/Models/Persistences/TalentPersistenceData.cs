using System;
using System.Collections.Generic;

namespace _Data.Refactor.Models.Persistences
{
    [Serializable]
    public class TalentPersistenceData
    {
        public int csPoints;
        public List<TalentLevelData> talentLevels = new List<TalentLevelData>();
    }

    [Serializable]
    public class TalentLevelData
    {
        public string talentId;
        public int level;
    }
}