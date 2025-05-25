using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMoving : VyesBehaviour
{
    [SerializeField] private YasuoStats yasuoStats;
    [SerializeField] private FindClosestEnemy findClosest;
    [SerializeField] private Rigidbody playerRigid;
    [SerializeField] private Animator playerAnimator;
    private Vector3 lastDirection = Vector3.forward;

    private void Update()
    {
        this.Move();
    }

    void Move()
    {
        float xDir = Input.GetAxis("Horizontal");
        float zDir = Input.GetAxis("Vertical");
        Vector3 moveDir = new Vector3(xDir, 0, zDir);

        float dis = this.findClosest.GetDistanceToTarget();

        if (dis > 7)
        {
            if (moveDir != Vector3.zero)
            {
                this.lastDirection = moveDir.normalized;
                this.transform.parent.rotation = Quaternion.Slerp(this.transform.parent.rotation,
                    this.GetRotation(this.lastDirection), Time.deltaTime * 5f);
            }
        }

        this.playerRigid.velocity = moveDir * this.yasuoStats.moveSpeed;
        this.playerAnimator.SetFloat("isRun", this.playerRigid.velocity.magnitude);
    }

    Quaternion GetRotation(Vector3 moveDir)
    {
        float angle = Mathf.Atan2(moveDir.x, moveDir.z) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, angle - 70, 0);
        return rotation;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadYasuoStats();
        this.LoadFindClosest();
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

    void LoadFindClosest()
    {
        if (this.findClosest != null) return;
        this.findClosest = FindObjectOfType<FindClosestEnemy>();
        Debug.LogWarning(this.transform.name + ": LoadFindClosest", this.gameObject);
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