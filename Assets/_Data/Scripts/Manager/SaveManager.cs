using System;
using System.IO;
using System.Linq;
using UnityEngine;

public class SaveManager : VyesSingleton<SaveManager>
{
    [SerializeField] private TalentTable talentTable;
    [SerializeField] private YasuoStats yasuoStats;

    string savePath => Application.persistentDataPath + "/save.json";

    public void SaveGame()
    {
        GameSaveData saveData = new GameSaveData
        {
            csPoint = this.talentTable.csPoint,
            talents = this.talentTable.talents.Select(t => new TalentForSave
            {
                type = t.type,
                currentLevel = t.currentLevel,
                effectValue = t.effectValue,
                pointCost = t.pointCost
            }).ToList()
        };

        string json = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(savePath, json);
        Debug.Log("Game saved to " + savePath);
    }

    public void LoadGame()
    {
        if (!File.Exists(savePath))
        {
            Debug.LogWarning("Save file not found at " + savePath);
            return;
        }

        string json = File.ReadAllText(savePath);
        GameSaveData saveData = JsonUtility.FromJson<GameSaveData>(json);
        this.talentTable.csPoint = saveData.csPoint;
        foreach (var data in saveData.talents)
        {
            var talent = this.talentTable.talents.FirstOrDefault(t => t.type == data.type);
            if (talent != null)
            {
                talent.currentLevel = data.currentLevel;
                talent.effectValue = data.effectValue;
                talent.pointCost = data.pointCost;
            }
        }
    }

    private void OnApplicationQuit()
    {
        this.SaveGame();
    }

    private void Start()
    {
        this.LoadGame();
    }
}