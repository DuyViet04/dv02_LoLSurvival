using System.Collections.Generic;
using UnityEngine;

namespace _Data.Refactor.Models.SOs.Talents
{
    [CreateAssetMenu(fileName = "TalentGroupSo", menuName = "SOs/Talents/TalentGroupSo")]
    public class TalentGroupSo : ScriptableObject
    {
        public List<TalentSo> talents;
    }
}