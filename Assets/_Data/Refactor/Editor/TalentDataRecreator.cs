using UnityEditor;
using UnityEngine;
using _Data.Refactor.Models.SOs.Talents;
using Base.Systems.Stat;
using System.Collections.Generic;
using System.IO;

namespace _Data.Refactor.Editor
{
    public class TalentDataRecreator
    {
        [MenuItem("Tools/Recreate Old Talents")]
        public static void Recreate()
        {
            string savePath = "Assets/Resources/SOs/Talents/";
            if (!Directory.Exists(Application.dataPath.Replace("Assets", "") + savePath))
            {
                Directory.CreateDirectory(Application.dataPath.Replace("Assets", "") + savePath);
            }

            // Data from old UpgradeSo and TalentTable
            var talentDefinitions = new List<TalentDef>
            {
                new TalentDef("Health", "Máu tối đa", "71273279a3ff9944c8b2474d1837dbfa", StatType.Health, ModifierType.Flat, 0, 75),
                new TalentDef("HealthRegen", "Hồi máu", "7e56a630275e2a34aa2618346ff4d985", StatType.HealthRegen, ModifierType.Flat, 0, 5),
                new TalentDef("AttackDamage", "Sức mạnh vật lý", "d34f17bd26010e14b976f98e6c6a89cc", StatType.AttackDamage, ModifierType.Flat, 0, 7),
                new TalentDef("AbilityPower", "Sức mạnh phép thuật", "8f35c8ebfbe3f7343ae5096b62d22192", StatType.AbilityPower, ModifierType.Flat, 0, 7),
                new TalentDef("Armor", "Giáp", "ee78fff7c577aef4189e5fc1f85edc96", StatType.Armor, ModifierType.Flat, 0, 9),
                new TalentDef("MagicResistance", "Kháng phép", "b37e99fbd2fcba24397a57b588c33f6f", StatType.MagicResist, ModifierType.Flat, 0, 9),
                new TalentDef("MoveSpeed", "Tốc độ di chuyển(%)", "9f20b277e4c39264b93dbde6e6b4e2a2", StatType.MoveSpeed, ModifierType.PercentMult, 0, 0.04f),
                new TalentDef("CriticalChance", "Tỉ lệ chí mạng(%)", "a46258bbcbc02c24cbdb4f6cf200303a", StatType.CritChance, ModifierType.Flat, 0, 5),
                new TalentDef("CriticalDamage", "Sát thương chí mạng(%)", "5f6e5aac16d098e43bc39d08f1d04d55", StatType.CritDamage, ModifierType.Flat, 0, 5),
                new TalentDef("ArmorPenetration", "Xuyên giáp", "1561921dc4b835349a65a7541eb6a193", StatType.ArmorPenetration, ModifierType.Flat, 0, 4),
                new TalentDef("MagicPenetration", "Xuyên kháng phép", "c1e5350459acebe4489dfdc7aafc8c32", StatType.MagicPenetration, ModifierType.Flat, 0, 4),
                new TalentDef("LifeSteal", "Hút máu(%)", "762dbb3105490a64c974aec6104b518e", StatType.LifeSteal, ModifierType.Flat, 0, 3),
                new TalentDef("Omnivamp", "Hút máu toàn phần(%)", "a0111dbd4f95bec408a771036bf1f3ff", StatType.Omnivamp, ModifierType.Flat, 0, 5),
                new TalentDef("Haste", "Hồi chiêu", "226cdd3f7c3c32b40973fcf77c5924d0", StatType.Haste, ModifierType.Flat, 0, 7),
                new TalentDef("HealingPower", "Sức mạnh hồi phục(%)", "f43efaa445229e045bd6c9cd442d2c55", StatType.HealPower, ModifierType.Flat, 0, 5),
                new TalentDef("PickUpRange", "Tầm nhặt(%)", "32d513c7817453549801ee98a64d30e0", StatType.PickUpRange, ModifierType.PercentMult, 0, 0.1f),
                new TalentDef("ExpMultiplier", "Kinh nghiệm(%)", "489ac8b39bb91734da93e97da99858ad", StatType.ExpMultiplier, ModifierType.Flat, 0, 5),
            };

            List<TalentSo> createdTalents = new List<TalentSo>();

            foreach (var def in talentDefinitions)
            {
                TalentSo talent = ScriptableObject.CreateInstance<TalentSo>();
                talent.talentId = def.id;
                talent.talentName = def.name;
                talent.statType = def.statType;
                talent.modifierType = def.modType;
                talent.baseValue = 0; // Bắt đầu từ 0 theo logic cũ
                talent.valuePerLevel = def.valPerLevel;
                talent.baseCost = 50; // Giá khởi điểm cũ
                talent.costPerLevel = 50; // Mỗi cấp tăng 50 cũ
                talent.maxLevel = 10;

                string iconPath = AssetDatabase.GUIDToAssetPath(def.iconGuid);
                if (!string.IsNullOrEmpty(iconPath))
                {
                    talent.icon = AssetDatabase.LoadAssetAtPath<Sprite>(iconPath);
                }

                string assetPath = savePath + "Talent_" + def.id + ".asset";
                AssetDatabase.CreateAsset(talent, assetPath);
                createdTalents.Add(talent);
            }

            // Create or Update TalentGroupSo
            string groupPath = savePath + "MainTalentGroup.asset";
            TalentGroupSo groupSo = AssetDatabase.LoadAssetAtPath<TalentGroupSo>(groupPath);
            if (groupSo == null)
            {
                groupSo = ScriptableObject.CreateInstance<TalentGroupSo>();
                AssetDatabase.CreateAsset(groupSo, groupPath);
            }
            groupSo.talents = createdTalents;
            EditorUtility.SetDirty(groupSo);

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            Debug.Log("Old Talents Recreated and added to MainTalentGroup!");
        }

        private struct TalentDef
        {
            public string id;
            public string name;
            public string iconGuid;
            public StatType statType;
            public ModifierType modType;
            public float baseVal;
            public float valPerLevel;

            public TalentDef(string id, string name, string iconGuid, StatType statType, ModifierType modType, float baseVal, float valPerLevel)
            {
                this.id = id;
                this.name = name;
                this.iconGuid = iconGuid;
                this.statType = statType;
                this.modType = modType;
                this.baseVal = baseVal;
                this.valPerLevel = valPerLevel;
            }
        }
    }
}
