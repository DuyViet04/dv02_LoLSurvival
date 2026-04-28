using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using _Data.Refactor.Enums.Enemies;
using _Data.Refactor.Models.SOs.Enemies;
using _Data.Refactor.Models.SOs.Enemies.Data;
using Base.Core.Architecture.Model.Data;
using Base.Systems.Combat;
using Base.Systems.Skill;
using Base.Systems.Stat;

namespace _Data.Refactor.Editor
{
    public class EnemyMigrationTool
    {
        private const string SavePath = "Assets/Resources/SOs/Enemies";

        [MenuItem("Tools/Refactor/Migrate Enemy SOs")]
        public static void Migrate()
        {
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }

            var enemies = GetEnemyMigrationData();

            foreach (var data in enemies)
            {
                CreateEnemySo(data);
            }

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            Debug.Log("Enemy SO Migration Complete using Reflection!");
        }

        private static void CreateEnemySo(MigrationData data)
        {
            string assetPath = $"{SavePath}/{data.Type}.asset";
            BaseEnemySo so = AssetDatabase.LoadAssetAtPath<BaseEnemySo>(assetPath);

            if (so == null)
            {
                so = ScriptableObject.CreateInstance<BaseEnemySo>();
                AssetDatabase.CreateAsset(so, assetPath);
            }

            // 1. Initialize EnemyData via Reflection (no parameterless constructor available)
            so.enemyData = (EnemyData)System.Runtime.Serialization.FormatterServices.GetUninitializedObject(typeof(EnemyData));
            SetPrivateField(so.enemyData, "enemyType", data.Type);
            SetPrivateField(so.enemyData, "expValue", CreateStat(StatType.ExpValue, data.Exp));
            SetPrivateField(so.enemyData, "goldValue", CreateStat(StatType.GoldValue, data.Gold));
            SetPrivateField(so.enemyData, "csValue", CreateStat(StatType.CsValue, data.Cs));
            SetPrivateField(so.enemyData, "spawnDelay", CreateStat(StatType.SpawnDelay, data.SpawnDelay));
            SetPrivateField(so.enemyData, "spawnCount", CreateStat(StatType.SpawnValue, data.SpawnCount));

            // 2. Initialize DefensiveData
            so.defensiveData = (BaseDefensiveData)System.Runtime.Serialization.FormatterServices.GetUninitializedObject(typeof(BaseDefensiveData));
            SetPrivateField(so.defensiveData, "health", CreateStat(StatType.Health, data.Health));
            SetPrivateField(so.defensiveData, "healthRegen", CreateStat(StatType.HealthRegen, 0f));
            SetPrivateField(so.defensiveData, "healPower", CreateStat(StatType.HealPower, 0f));
            SetPrivateField(so.defensiveData, "armor", CreateStat(StatType.Armor, data.Armor));
            SetPrivateField(so.defensiveData, "magicResist", CreateStat(StatType.MagicResist, data.MR));
            SetPrivateField(so.defensiveData, "tenacity", CreateStat(StatType.Tenacity, 0f));
            SetPrivateField(so.defensiveData, "slowResist", CreateStat(StatType.SlowResist, 0f));

            // 3. Initialize UtilityData
            so.utilityData = (BaseUtilityData)System.Runtime.Serialization.FormatterServices.GetUninitializedObject(typeof(BaseUtilityData));
            SetPrivateField(so.utilityData, "haste", CreateStat(StatType.Haste, 0f));
            SetPrivateField(so.utilityData, "resourceData", CreateResourceData());
            SetPrivateField(so.utilityData, "moveSpeed", CreateStat(StatType.MoveSpeed, data.MoveSpeed));

            // 4. Initialize OffensiveData
            so.offensiveData = (BaseOffensiveData)System.Runtime.Serialization.FormatterServices.GetUninitializedObject(typeof(BaseOffensiveData));
            SetPrivateField(so.offensiveData, "attackSpeed", CreateStat(StatType.AttackSpeed, 0f));
            SetPrivateField(so.offensiveData, "attackDamage", CreateStat(StatType.AttackDamage, data.Damage));
            SetPrivateField(so.offensiveData, "abilityPower", CreateStat(StatType.AbilityPower, 0f));
            SetPrivateField(so.offensiveData, "critChance", CreateStat(StatType.CritChance, 0f));
            SetPrivateField(so.offensiveData, "critDamage", CreateStat(StatType.CritDamage, 0f));
            SetPrivateField(so.offensiveData, "armorPenetration", CreateStat(StatType.ArmorPenetration, 0f));
            SetPrivateField(so.offensiveData, "magicPenetration", CreateStat(StatType.MagicPenetration, 0f));
            SetPrivateField(so.offensiveData, "lifeSteal", CreateStat(StatType.LifeSteal, 0f));
            SetPrivateField(so.offensiveData, "physicalVamp", CreateStat(StatType.PhysicalVamp, 0f));
            SetPrivateField(so.offensiveData, "omnivamp", CreateStat(StatType.Omnivamp, 0f));

            // 5. Initialize AttackData (Using the only available constructor)
            so.attackData = new AttackData(data.Damage, false, 0, data.DmgType);

            EditorUtility.SetDirty(so);
        }

        private static void SetPrivateField(object target, string fieldName, object value)
        {
            var field = target.GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
            if (field != null)
            {
                field.SetValue(target, value);
            }
            else
            {
                Debug.LogWarning($"Field {fieldName} not found in {target.GetType().Name}");
            }
        }

        private static Stat CreateStat(StatType type, float value)
        {
            Stat stat = new Stat(value);
            SetPrivateField(stat, "statType", type);
            return stat;
        }

        private static ResourceData CreateResourceData()
        {
            ResourceData data = (ResourceData)System.Runtime.Serialization.FormatterServices.GetUninitializedObject(typeof(ResourceData));
            SetPrivateField(data, "resourceType", ResourceType.Mana);
            SetPrivateField(data, "resource", CreateStat(StatType.Resource, 0f));
            SetPrivateField(data, "resourceRegen", CreateStat(StatType.ResourceRegen, 0f));
            return data;
        }

        private static List<MigrationData> GetEnemyMigrationData()
        {
            return new List<MigrationData>
            {
                new MigrationData(EnemyType.Blue, 230, 42, 42, 2.75f, 95, 90, 4, 360, 1, 66, DamageType.Magical),
                new MigrationData(EnemyType.Red, 230, 42, 42, 2.75f, 95, 90, 4, 420, 1, 66, DamageType.Magical),
                new MigrationData(EnemyType.MeleeEnemy, 46.5f, 20, 1, 1.5f, 61.75f, 21, 1, 3, 3, 11, DamageType.Physical),
                new MigrationData(EnemyType.RangeEnemy, 28.4f, 1, 1, 1.5f, 30.4f, 14, 1, 6, 3, 21, DamageType.Physical),
                new MigrationData(EnemyType.CannonEnemy, 83.5f, 1, 1, 1.5f, 95, 60, 1, 30, 1, 37.5f, DamageType.Physical),
                new MigrationData(EnemyType.SuperEnemy, 160, 100, -30, 1.5f, 95, 60, 1, 60, 1, 215, DamageType.Physical),
                new MigrationData(EnemyType.Gromp, 205, 42, 42, 3.3f, 120, 80, 4, 120, 1, 70, DamageType.Magical),
                new MigrationData(EnemyType.MurkWolfL, 160, 42, 42, 5.25f, 50, 50, 2, 180, 1, 30, DamageType.Magical),
                new MigrationData(EnemyType.MurkWolfS, 63, 20, 20, 5.25f, 15, 15, 1, 180, 2, 10, DamageType.Magical),
                new MigrationData(EnemyType.RaptorL, 120, 42, 42, 4.5f, 20, 30, 2, 240, 1, 17, DamageType.Magical),
                new MigrationData(EnemyType.RaptorS, 50, 20, 20, 5.25f, 10, 8, 0.4f, 240, 5, 7, DamageType.Magical),
                new MigrationData(EnemyType.KrugL, 135, 42, 42, 2.5f, 15, 15, 2, 300, 1, 57, DamageType.Magical),
                new MigrationData(EnemyType.KrugM, 65, 20, 20, 3.5f, 10, 10, 0.5f, 300, 2, 20, DamageType.Magical),
                new MigrationData(EnemyType.KrugS, 6, 20, 20, 4, 16, 14, 0.25f, 300, 2, 13, DamageType.Magical)
            };
        }

        private struct MigrationData
        {
            public EnemyType Type;
            public float Health;
            public float Armor;
            public float MR;
            public float MoveSpeed;
            public float Exp;
            public float Gold;
            public float Cs;
            public float SpawnDelay;
            public float SpawnCount;
            public float Damage;
            public DamageType DmgType;

            public MigrationData(EnemyType type, float health, float armor, float mr, float moveSpeed, float exp, float gold, float cs, float spawnDelay, float spawnCount, float damage, DamageType dmgType)
            {
                Type = type;
                Health = health;
                Armor = armor;
                MR = mr;
                MoveSpeed = moveSpeed;
                Exp = exp;
                Gold = gold;
                Cs = cs;
                SpawnDelay = spawnDelay;
                SpawnCount = spawnCount;
                Damage = damage;
                DmgType = dmgType;
            }
        }
    }
}
