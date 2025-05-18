using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MeleeEnemyStats meleeEnemyStats;
    [SerializeField] private RarityTable rarityTable;
    [SerializeField] private UpgradeTable upgradeTable;

    void Start()
    {
        this.rarityTable.ResetData();
        this.meleeEnemyStats.ResetStats();
        this.upgradeTable.ResetData();
    }
}