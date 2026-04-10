using System.Collections.Generic;
using System.Linq;
using _Data.Refactor.Models.SOs.Players;
using UnityEngine;
using VyesBase.Core.Singleton;
using VyesBase.Systems.Skills;
using VyesBase.Utils.GameLogger;

namespace _Data.Refactor.Managers
{
    public class SoManager : VyesSingleton<SoManager>
    {
        [SerializeField] private List<BasePlayerSo> playerSos;
        private Dictionary<string, List<BaseSkillSo>> skillSos = new Dictionary<string, List<BaseSkillSo>>();

        private readonly string playerSosPath = "SOs/Players";
        private readonly string baseSkillSosPath = "SOs/Skills/";

        private readonly List<string> folders = new List<string>
        {
            "Yasuo"
        };

        public BasePlayerSo GetPlayerSoByName(string playerName)
        {
            foreach (BasePlayerSo so in playerSos)
            {
                if (so.characterName == playerName)
                {
                    return so;
                }
            }

            GameLogger.LogError($"PlayerSo: {playerName} not found");
            return null;
        }

        public List<BaseSkillSo> GetSkillsSoByName(string charName)
        {
            foreach (var key in skillSos.Keys)
            {
                if (key == charName)
                {
                    return skillSos[key];
                }
            }

            GameLogger.LogError($"Skills: {charName} not found");
            return null;
        }

        protected override void LoadComponents()
        {
            base.LoadComponents();
            var player = Resources.LoadAll<BasePlayerSo>(playerSosPath);
            if (playerSos.Count != player.Length) playerSos.AddRange(player);

            LoadSkillSo();
        }

        void LoadSkillSo()
        {
            foreach (var folder in folders)
            {
                var path = baseSkillSosPath + folder;
                var skill = Resources.LoadAll<BaseSkillSo>(path);
                if (!skillSos.ContainsKey(folder) || skillSos[folder].Count != skill.Length)
                    skillSos.Add(folder, skill.ToList());
            }
        }
    }
}