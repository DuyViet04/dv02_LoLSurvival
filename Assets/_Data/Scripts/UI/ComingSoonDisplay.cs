using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComingSoonDisplay : VyesBehaviour
{
    [SerializeField] private GameObject lockPanel;

    protected override void Awake()
    {
        base.Awake();
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

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLockPanel();
    }

    void LoadLockPanel()
    {
        if (this.lockPanel != null) return;
        this.lockPanel = GameObject.Find("LockPanel");
        Debug.LogWarning(this.transform.name + ": LoadLockPanel", this.gameObject);
    }
}