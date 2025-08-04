using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComingSoonDisplay : MonoBehaviour
{
    [SerializeField] private GameObject lockPanel;

    private void Awake()
    {
        this.lockPanel.SetActive(false);
    }

    public void OpenLockPanel()
    {
        this.lockPanel.SetActive(true);
    }

    public void CloseLockPanel()
    {
        this.lockPanel.SetActive(false);
    }
}