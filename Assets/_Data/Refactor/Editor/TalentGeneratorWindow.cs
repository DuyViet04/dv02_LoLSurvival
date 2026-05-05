using UnityEditor;
using UnityEngine;
using _Data.Refactor.Models.SOs.Talents;
using Base.Systems.Stat;
using System.IO;

namespace _Data.Refactor.Editor
{
    public class TalentGeneratorWindow : EditorWindow
    {
        private string talentId;
        private string talentName;
        private Sprite icon;
        private string description;

        private StatType statType = StatType.Health;
        private ModifierType modifierType = ModifierType.Flat;
        private float baseValue = 10f;
        private float valuePerLevel = 5f;

        private int baseCost = 100;
        private int costPerLevel = 50;
        private int maxLevel = 10;

        private TalentGroupSo talentGroupSo;
        private string savePath = "Assets/Resources/SOs/Talents/";

        [MenuItem("Tools/Talent Generator")]
        public static void ShowWindow()
        {
            GetWindow<TalentGeneratorWindow>("Talent Generator");
        }

        private void OnGUI()
        {
            GUILayout.Label("Create New Talent", EditorStyles.boldLabel);

            talentId = EditorGUILayout.TextField("Talent ID", talentId);
            talentName = EditorGUILayout.TextField("Talent Name", talentName);
            icon = (Sprite)EditorGUILayout.ObjectField("Icon", icon, typeof(Sprite), false);
            
            GUILayout.Label("Description");
            description = EditorGUILayout.TextArea(description, GUILayout.Height(60));

            EditorGUILayout.Space();
            GUILayout.Label("Stat Settings", EditorStyles.boldLabel);
            statType = (StatType)EditorGUILayout.EnumPopup("Stat Type", statType);
            modifierType = (ModifierType)EditorGUILayout.EnumPopup("Modifier Type", modifierType);
            baseValue = EditorGUILayout.FloatField("Base Value", baseValue);
            valuePerLevel = EditorGUILayout.FloatField("Value Per Level", valuePerLevel);

            EditorGUILayout.Space();
            GUILayout.Label("Cost Settings", EditorStyles.boldLabel);
            baseCost = EditorGUILayout.IntField("Base Cost", baseCost);
            costPerLevel = EditorGUILayout.IntField("Cost Per Level", costPerLevel);
            maxLevel = EditorGUILayout.IntField("Max Level", maxLevel);

            EditorGUILayout.Space();
            savePath = EditorGUILayout.TextField("Save Path", savePath);
            talentGroupSo = (TalentGroupSo)EditorGUILayout.ObjectField("Add to Group", talentGroupSo, typeof(TalentGroupSo), false);

            if (GUILayout.Button("Generate Talent SO"))
            {
                GenerateTalent();
            }
        }

        private void GenerateTalent()
        {
            if (string.IsNullOrEmpty(talentId))
            {
                Debug.LogError("Talent ID cannot be empty!");
                return;
            }

            string fullPath = Application.dataPath.Replace("Assets", "") + savePath;
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }

            TalentSo talentSo = CreateInstance<TalentSo>();
            talentSo.talentId = talentId;
            talentSo.talentName = talentName;
            talentSo.icon = icon;
            talentSo.description = description;
            talentSo.statType = statType;
            talentSo.modifierType = modifierType;
            talentSo.baseValue = baseValue;
            talentSo.valuePerLevel = valuePerLevel;
            talentSo.baseCost = baseCost;
            talentSo.costPerLevel = costPerLevel;
            talentSo.maxLevel = maxLevel;

            string assetPath = savePath + talentId + ".asset";
            AssetDatabase.CreateAsset(talentSo, assetPath);

            if (talentGroupSo != null)
            {
                if (!talentGroupSo.talents.Contains(talentSo))
                {
                    talentGroupSo.talents.Add(talentSo);
                    EditorUtility.SetDirty(talentGroupSo);
                }
            }

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            Debug.Log($"Talent SO '{talentId}' generated at {assetPath}");
            Selection.activeObject = talentSo;
        }
    }
}
