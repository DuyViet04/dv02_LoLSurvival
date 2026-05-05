using System.IO;
using _Data.Refactor.Models.Persistences;
using _Data.Refactor.Services.Talents;
using Base.Core.Singleton;
using UnityEngine;

namespace _Data.Refactor.Services.SaveLoad
{
    public class SaveService : VyesPersistentSingleton<SaveService>
    {
        private string SavePath => Application.persistentDataPath + "/savegame.json";
        private GamePersistenceData currentData = new GamePersistenceData();

        public GamePersistenceData CurrentData => currentData;

        protected override void Awake()
        {
            base.Awake();
            LoadGame();
        }

        public void SaveGame()
        {
            // Thu thập dữ liệu từ các service khác
            currentData.talentData = TalentService.Ins.GetPersistenceData();

            string json = JsonUtility.ToJson(currentData, true);
            File.WriteAllText(SavePath, json);
            Debug.Log($"[SaveService] Game saved to: {SavePath}");
        }

        public void LoadGame()
        {
            if (!File.Exists(SavePath))
            {
                Debug.Log("[SaveService] No save file found, starting new game.");
                return;
            }

            string json = File.ReadAllText(SavePath);
            currentData = JsonUtility.FromJson<GamePersistenceData>(json);
            
            // Phân phối dữ liệu cho các service khác
            TalentService.Ins.LoadFromPersistenceData(currentData.talentData);
            
            Debug.Log("[SaveService] Game loaded successfully.");
        }

        private void OnApplicationQuit()
        {
            SaveGame();
        }
        
        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus) SaveGame();
        }
    }
}
