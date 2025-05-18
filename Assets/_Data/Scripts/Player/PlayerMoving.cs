using System;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] private YasuoStats baseYasuoStats;
    [SerializeField] private FindClosestEnemy findClosest;
    [SerializeField] private Rigidbody playerRigid;
    [SerializeField] private Animator playerAnimator;
    private YasuoStats yasuoStats;
    private Vector3 lastDirection = Vector3.forward;

    private void Awake()
    {
        this.yasuoStats = Instantiate(this.baseYasuoStats);
    }

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
}