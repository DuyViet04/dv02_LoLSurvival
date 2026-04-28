using System.Collections.Generic;
using _Data.Refactor.Models.SOs.Enemies;
using _Data.Refactor.Models.SOs.Players;
using _Data.Refactor.Models.SOs.Upgrades;
using Base.Core.Singleton;
using UnityEngine;

namespace _Data.Refactor.Managers
{
    public class SoManager : VyesSingleton<SoManager>
    {
        [SerializeField] private List<BasePlayerSo> playerSos;
        [SerializeField] private List<BaseEnemySo> enemySos;
        [SerializeField] private UpgradeTable upgradeTable;

        public List<BaseEnemySo> EnemySos => enemySos;
        public UpgradeTable UpgradeTable => upgradeTable;

        private readonly string playerSosPath = "SOs/Players";
        private readonly string enemySosPath = "SOs/Enemies";
        private readonly string upgradeTablePath = "SOs/Upgrades";

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

        public BaseEnemySo GetEnemySoByName(string enemyName)
        {
            foreach (BaseEnemySo so in enemySos)
            {
                if (so.enemyData.EnemyType.ToString() == enemyName)
                {
                    return so;
                }
            }

            Debug.LogError($"EnemySo: {enemyName} not found");
            return null;
        }

        protected override void LoadComponents()
        {
            base.LoadComponents();
            var player = Resources.LoadAll<BasePlayerSo>(playerSosPath);
            if (playerSos.Count != player.Length)
            {
                playerSos.AddRange(player);
                Debug.LogWarning($"Load {playerSos}");
            }

            var enemy = Resources.LoadAll<BaseEnemySo>(enemySosPath);
            if (enemySos.Count != enemy.Length)
            {
                enemySos.AddRange(enemy);
                Debug.LogWarning($"Load {enemySos}");
            }

            if (upgradeTable == null)
            {
                upgradeTable = Resources.LoadAll<UpgradeTable>(upgradeTablePath)[0];
                Debug.LogWarning($"Load {upgradeTable}", gameObject);
            }
        }
    }
}