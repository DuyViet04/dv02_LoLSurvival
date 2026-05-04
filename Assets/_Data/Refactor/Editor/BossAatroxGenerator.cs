using UnityEditor;
using UnityEngine;
using _Data.Refactor.Models.SOs.Enemies;
using Base.Systems.Skill;
using System.Collections.Generic;
using _Data.Refactor.Models.SOs.Enemies.Data;
using Base.Systems.Combat;
using Base.Systems.Stat;
using _Data.Refactor.Enums.Enemies;

namespace _Data.Refactor.Editor
{
    public class BossAatroxGenerator
    {
        [MenuItem("Tools/Generate Boss Aatrox SO")]
        public static void Generate()
        {
            string bossPath = "Assets/Resources/SOs/Enemies/Boss/";
            string skillPath = "Assets/Resources/SOs/Skills/Boss/Aatrox/";

            if (!System.IO.Directory.Exists(Application.dataPath.Replace("Assets", "") + bossPath))
            {
                System.IO.Directory.CreateDirectory(Application.dataPath.Replace("Assets", "") + bossPath);
            }
            if (!System.IO.Directory.Exists(Application.dataPath.Replace("Assets", "") + skillPath))
            {
                System.IO.Directory.CreateDirectory(Application.dataPath.Replace("Assets", "") + skillPath);
            }

            // 1. Create Skills
            List<BaseSkillSo> skills = new List<BaseSkillSo>();
            skills.Add(CreateSkill(skillPath + "Aatrox_Q1.asset", 10, 60, 12));
            skills.Add(CreateSkill(skillPath + "Aatrox_Q2.asset", 12.5f, 75, 0));
            skills.Add(CreateSkill(skillPath + "Aatrox_Q3.asset", 15, 90, 0));

            // 2. Create Boss SO
            BaseBossSo bossSo = ScriptableObject.CreateInstance<BaseBossSo>();
            bossSo.skills = skills;
            
            SerializedObject so = new SerializedObject(bossSo);
            
            // Defensive Data
            var defensive = so.FindProperty("defensiveData");
            SetStat(defensive.FindPropertyRelative("health"), 1300);
            SetStat(defensive.FindPropertyRelative("healthRegen"), 6);
            SetStat(defensive.FindPropertyRelative("armor"), 76);
            SetStat(defensive.FindPropertyRelative("magicResist"), 64);
            
            // Offensive Data
            var offensive = so.FindProperty("offensiveData");
            SetStat(offensive.FindPropertyRelative("attackDamage"), 120);
            
            // Utility Data
            var utility = so.FindProperty("utilityData");
            SetStat(utility.FindPropertyRelative("moveSpeed"), 3);
            
            // Enemy Data (Exp, Gold, etc. - default values)
            var enemyData = so.FindProperty("enemyData");
            enemyData.FindPropertyRelative("<EnemyType>k__BackingField").enumValueIndex = (int)EnemyType.Boss;
            SetStat(enemyData.FindPropertyRelative("<ExpValue>k__BackingField"), 500);
            SetStat(enemyData.FindPropertyRelative("<GoldValue>k__BackingField"), 1000);
            SetStat(enemyData.FindPropertyRelative("<CsValue>k__BackingField"), 1);
            
            // Attack Data
            var attackData = so.FindProperty("attackData");
            attackData.FindPropertyRelative("<Damage>k__BackingField").floatValue = 120;

            so.ApplyModifiedProperties();
            
            AssetDatabase.CreateAsset(bossSo, bossPath + "BossAatrox.asset");
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            
            Debug.Log("Boss Aatrox SO Generated at " + bossPath);
        }

        private static BaseSkillSo CreateSkill(string path, float damage, float bonusAd, float cd)
        {
            BaseSkillSo skill = ScriptableObject.CreateInstance<BaseSkillSo>();
            SerializedObject so = new SerializedObject(skill);
            var data = so.FindProperty("skillData");
            data.FindPropertyRelative("baseDamage").floatValue = damage;
            data.FindPropertyRelative("bonusAd").floatValue = bonusAd;
            data.FindPropertyRelative("cooldown").floatValue = cd;
            so.ApplyModifiedProperties();
            AssetDatabase.CreateAsset(skill, path);
            return skill;
        }

        private static void SetStat(SerializedProperty statProp, float value)
        {
            statProp.FindPropertyRelative("value").floatValue = value;
        }
    }
}
