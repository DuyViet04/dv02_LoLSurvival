using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float moveSpeed = 3f;
    private bool isMove;

    public void StartMove()
    {
        this.isMove = true;
    }

    public void PickUp()
    {
        LevelUp levelUp = GameObject.FindObjectOfType<LevelUp>();
        ExpSpawner.Instance.Despawn(this.transform.parent);
        levelUp.IncreaseExp();
    }

    public void MoveToTarget(Transform target)
    {
        Vector3 pos = Vector3.MoveTowards(this.transform.parent.position, target.position,
            this.moveSpeed * Time.deltaTime);
        this.transform.parent.position = pos;
    }

    private void Update()
    {
        if (this.isMove && this.target != null)
        {
            MoveToTarget(this.target);

            if (this.transform.parent.position != this.target.position) return;
            this.isMove = false;
            PickUp();
        }
    }
}