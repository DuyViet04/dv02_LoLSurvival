using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRigid;
    [SerializeField] private float moveSpeed = 7f;

    private void Update()
    {
        this.Move();
    }

    void Move()
    {
        float xDir = Input.GetAxis("Horizontal");
        float zDir = Input.GetAxis("Vertical");
        Vector3 moveDir = new Vector3(xDir, 0, zDir);
        
        this.playerRigid.velocity = moveDir * this.moveSpeed;
    }
}
