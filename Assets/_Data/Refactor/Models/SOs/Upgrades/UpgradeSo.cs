using System.Collections.Generic;
using _Data.Refactor.Models.SOs.Upgrades.Data;
using UnityEngine;

namespace _Data.Refactor.Models.SOs.Upgrades
{
    [CreateAssetMenu(fileName = "UpgradeSo", menuName = "SOs/Upgrades/UpgradeSo")]
    public class UpgradeSo : ScriptableObject
    {
        public List<UpgradeData> upgrades;
    }
}