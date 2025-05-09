using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private YasuoStats stats;
    LevelUp levelUp;

    private void Start()
    {
        this.levelUp = FindObjectOfType<LevelUp>();

        this.pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.PauseGame();
        }
    }

    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        this.UpdateData();
    }

    public void ContinueGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    void UpdateData()
    {
        FieldInfo[] fieldInfo = this.GetYasuoStatFields();
        StatsInforManager.Instance.mainData[0].text = this.levelUp.GetCurrentLevel().ToString();

        for (int i = 1; i < 17; i++)
        {
            StatsInforManager.Instance.mainData[i].text = fieldInfo[i].GetValue(stats).ToString();
        }
    }

    //Refection
    FieldInfo[] GetYasuoStatFields()
    {
        return typeof(YasuoStats).GetFields(BindingFlags.Public | BindingFlags.Instance);
    }
}