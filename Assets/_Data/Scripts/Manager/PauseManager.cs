using System.Reflection;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject levelUpPanel;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private YasuoStats stats;
    private LevelUp levelUp;
    private bool isLevelUp;

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
        this.isLevelUp = this.levelUpPanel.activeSelf;

        if (this.isLevelUp) this.levelUpPanel.SetActive(false);
        pauseMenu.SetActive(true);
        StatsInforManager.Instance.mainStatsPanel.SetActive(true);
        Time.timeScale = 0;
        this.UpdateMainData();
        this.UpdateSecondData();
    }

    public void ContinueGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;

        if (this.isLevelUp)
        {
            this.levelUpPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void UpdateMainData()
    {
        FieldInfo[] fieldInfo = this.GetYasuoStatFields();
        StatsInforManager.Instance.mainData[0].text = this.levelUp.GetCurrentLevel().ToString();

        for (int i = 1; i < 17; i++)
        {
            StatsInforManager.Instance.mainData[i].text = $"{fieldInfo[i].GetValue(stats):F2}";
        }
    }

    void UpdateSecondData()
    {
        FieldInfo[] fieldInfo = this.GetYasuoStatFields();
        for (int i = 17; i < 19; i++)
        {
            StatsInforManager.Instance.secondData[i - 17].text = $"{fieldInfo[i].GetValue(stats):F2}";
        }
    }

    //Refection
    FieldInfo[] GetYasuoStatFields()
    {
        return typeof(YasuoStats).GetFields(BindingFlags.Public | BindingFlags.Instance);
    }
}