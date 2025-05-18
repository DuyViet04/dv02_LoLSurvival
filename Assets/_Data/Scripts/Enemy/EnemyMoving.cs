using System;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    [SerializeField] private MeleeEnemyStats baseMeleeEnemyStats;
    [SerializeField] private Transform target;
    private MeleeEnemyStats meleeEnemyStats;

    private void Awake()
    {
        this.meleeEnemyStats = Instantiate(this.baseMeleeEnemyStats);
    }

    private void Update()
    {
        this.MoveToTarget();
    }

    void MoveToTarget()
    {
        this.transform.parent.position = Vector3.MoveTowards(this.transform.parent.position, this.target.position,
            this.meleeEnemyStats.moveSpeed * Time.deltaTime);
    }
}