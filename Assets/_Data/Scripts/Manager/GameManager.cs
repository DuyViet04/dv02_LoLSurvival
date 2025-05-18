using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private RarityTable rarityTable;
    [SerializeField] private UpgradeTable upgradeTable;

    void Start()
    {
        this.rarityTable.ResetData();
        this.upgradeTable.ResetData();
    }
}