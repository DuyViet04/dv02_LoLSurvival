using System.Collections.Generic;
using _Data.Refactor.Models.SOs.Enemies;
using _Data.Refactor.Models.SOs.Players;
using Base.Core.Singleton;
using UnityEngine;

namespace _Data.Refactor.Managers
{
    public class SoManager : VyesSingleton<SoManager>
    {
        [SerializeField] private List<BasePlayerSo> playerSos;
        [SerializeField] private List<BaseEnemySo> enemySos;

        private readonly string playerSosPath = "SOs/Players";
        private readonly string enemySosPath = "SOs/Enemies";

        public BasePlayerSo GetPlayerSoByName(string playerName)
        {
            foreach (BasePlayerSo so in playerSos)
            {
                if (so.playerData.CharName == playerName)
                {
                    return so;
                }
            }

            Debug.LogError($"PlayerSo: {playerName} not found");
            return null;
        }

        protected override void LoadComponents()
        {
            base.LoadComponents();
            var player = Resources.LoadAll<BasePlayerSo>(playerSosPath);
            if (playerSos.Count != player.Length)
            {
                Debug.LogWarning($"Load {playerSos}");
                playerSos.AddRange(player);
            }

            var enemy = Resources.LoadAll<BaseEnemySo>(enemySosPath);
            if (enemySos.Count != enemy.Length)
            {
                Debug.LogWarning($"Load {enemySos}");
                enemySos.AddRange(enemy);
            }
        }
    }
}