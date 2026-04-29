using System.Collections.Generic;
using _Data.Refactor.Models.SOs.Upgrades.Data;
using UnityEngine;

namespace _Data.Refactor.Models.SOs.Upgrades
{
    [CreateAssetMenu(fileName = "RarityTable", menuName = "SOs/Upgrades/RarityTable")]
    public class RaritySo : ScriptableObject
    {
        public List<RarityData> rarities;
    }
}