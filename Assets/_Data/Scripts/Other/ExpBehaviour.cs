using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class ExpBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private float moveSpeed = 3f;
    private float expValue;
    private bool isMove;

    private void Update()
    {
        if (this.isMove && this.target != null)
        {
            this.MoveToTarget(this.target.transform);
            float distance = Vector3.Distance(this.transform.parent.position, this.target.transform.position);
            if (distance > 0.5f) return;
            this.isMove = false;
            this.PickUp();
        }
    }

    public void SetExpValue(float value)
    {
        this.expValue = value;
    }

    public void StartMove()
    {
        this.isMove = true;
    }

    private void PickUp()
    {
        LevelUp levelUp = FindObjectOfType<LevelUp>();
        ExpSpawner.Instance.Despawn(this.transform.parent);
        levelUp.IncreaseExp(this.expValue);
    }

    private void MoveToTarget(Transform target)
    {
        Vector3 pos = Vector3.Lerp(this.transform.parent.position, target.position, this.moveSpeed * Time.deltaTime);
        this.transform.parent.position = pos;
    }
}