using System.Collections.Generic;
using _Data.Refactor.Models.SOs.Upgrades.Data;
using UnityEngine;

namespace _Data.Refactor.Models.SOs.Upgrades
{
    [CreateAssetMenu(fileName = "UpgradeTable", menuName = "SOs/Upgrades/UpgradeTable")]
    public class UpgradeTable : ScriptableObject
    {
        public List<UpgradeData> upgrades;
    }
}