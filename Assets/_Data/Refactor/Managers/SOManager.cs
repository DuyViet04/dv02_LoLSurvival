using System.Collections.Generic;
using _Data.Refactor.Models.SOs.Enemies;
using _Data.Refactor.Models.SOs.Items;
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
        [SerializeField] private UpgradeSo upgradeSo;
        [SerializeField] private RaritySo raritySo;
        [SerializeField] private List<ItemSo> itemSos;
        [SerializeField] private ItemRaritySo itemRaritySo;

        public List<BaseEnemySo> EnemySos => enemySos;
        public UpgradeSo UpgradeSo => upgradeSo;
        public RaritySo RaritySo => raritySo;
        public List<ItemSo> ItemSos => itemSos;
        public ItemRaritySo ItemRaritySo => itemRaritySo;

        private readonly string playerSosPath = "SOs/Players";
        private readonly string enemySosPath = "SOs/Enemies";
        private readonly string upgradeSosPath = "SOs/Upgrades";
        private readonly string raritySosPath = "SOs/Items";

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

            if (upgradeSo == null)
            {
                upgradeSo = Resources.LoadAll<UpgradeSo>(upgradeSosPath)[0];
                Debug.LogWarning($"Load {upgradeSo}", gameObject);
            }

            if (raritySo == null)
            {
                raritySo = Resources.LoadAll<RaritySo>(upgradeSosPath)[0];
                Debug.LogWarning($"Load {raritySo}", gameObject);
            }

            var item = Resources.LoadAll<ItemSo>(raritySosPath);
            if (item.Length != itemSos.Count)
            {
                itemSos.AddRange(item);
                Debug.LogWarning($"Load {itemSos}", gameObject);
            }
        }
    }
}