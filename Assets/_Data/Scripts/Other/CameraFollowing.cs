using UnityEngine;

public class CameraFollowing : VyesBehaviour
{
    [SerializeField] private Transform target;

    private void Update()
    {
        this.Follow(this.target);
    }

    void Follow(Transform target)
    {
        Vector3 targetPos = new Vector3(target.position.x, 10, target.position.z);
        Vector3 pos = Vector3.Lerp(this.transform.position, targetPos, 1f);
        this.transform.position = pos;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTarget();
    }

    void LoadTarget()
    {
        if (this.target != null) return;
        this.target = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.LogWarning(this.transform.name + ": LoadTarget", this.gameObject);
    }
}