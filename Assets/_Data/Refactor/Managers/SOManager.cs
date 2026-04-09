using System.Collections.Generic;
using _Data.Refactor.Models.SOs.Players;
using UnityEngine;
using VyesBase.Core.Singleton;
using VyesBase.Utils.GameLogger;

namespace _Data.Refactor.Managers
{
    public class SoManager : VyesSingleton<SoManager>
    {
        [SerializeField] private List<BasePlayerSo> playerSos;

        private readonly string playerSosPath = "SOs/Players";

        public BasePlayerSo GetPlayerSoByName(string playerName)
        {
            foreach (BasePlayerSo so in this.playerSos)
            {
                if (so.characterName == playerName)
                {
                    return so;
                }
            }

            GameLogger.LogError($"PlayerSo: {playerName} not found");
            return null;
        }

        // public MainBossStats GetBossStatsByType(string type)
        // {
        //     foreach (var item in this.bossStatsList)
        //     {
        //         string typeName = item.bossType.ToString();
        //         if (typeName == type) return item;
        //     }
        //
        //     return null;
        // }
        //
        // public List<MainEnemyStats> GetEnemyStatsList()
        // {
        //     return this.enemyStatsList;
        // }
        //
        // public YasuoStats GetYasuoStats()
        // {
        //     return this.yasuoStats;
        // }
        //
        // public YasuoSkill GetYasuoSkill()
        // {
        //     return this.yasuoSkill;
        // }

        protected override void LoadComponents()
        {
            base.LoadComponents();
            var player = Resources.LoadAll<BasePlayerSo>(playerSosPath);
            if (playerSos.Count != player.Length) playerSos.AddRange(player);
        }
    }
}