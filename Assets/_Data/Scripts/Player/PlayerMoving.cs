using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMoving : VyesBehaviour
{
    [SerializeField] private YasuoStats yasuoStats;
    [SerializeField] private Rigidbody playerRigid;
    [SerializeField] private Animator playerAnimator;

    private void Update()
    {
        this.Move();
    }

    void Move()
    {
        float xDir = Input.GetAxis("Horizontal");
        float zDir = Input.GetAxis("Vertical");
        Vector3 moveDir = new Vector3(xDir, 0, zDir);

        this.playerRigid.velocity = moveDir * this.yasuoStats.moveSpeed;
        this.playerAnimator.SetFloat("isRun", this.playerRigid.velocity.magnitude);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadYasuoStats();
        this.LoadAnimator();
        this.LoadRigidbody();
    }

    void LoadYasuoStats()
    {
        if (this.yasuoStats != null) return;
        string[] guids = AssetDatabase.FindAssets("t:YasuoStats", new[] { "Assets/_Data/Scripts/Stat/Character/SO" });
        string path = AssetDatabase.GUIDToAssetPath(guids[0]);
        this.yasuoStats = AssetDatabase.LoadAssetAtPath<YasuoStats>(path);
        Debug.LogWarning(this.transform.name + ": LoadYasuoStats", this.gameObject);
    }

    void LoadAnimator()
    {
        if (this.playerAnimator != null) return;
        this.playerAnimator = this.transform.parent.GetComponentInChildren<Animator>();
        Debug.LogWarning(this.transform.name + ": LoadAnimator", this.gameObject);
    }

    void LoadRigidbody()
    {
        if (this.playerRigid != null) return;
        this.playerRigid = this.transform.parent.GetComponent<Rigidbody>();
        Debug.LogWarning(this.transform.name + ": LoadRigidbody", this.gameObject);
    }
}