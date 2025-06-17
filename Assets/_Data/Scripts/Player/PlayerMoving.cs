using UnityEngine;

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
        // Lấy giá trị từ bàn phím 
        float xDir = Input.GetAxis("Horizontal"); 
        float zDir = Input.GetAxis("Vertical");
        Vector3 moveDir = new Vector3(xDir, 0, zDir); // Tạo vector di chuyển từ các giá trị bàn phím

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
        this.yasuoStats = SOManager.Instance.GetYasuoStats();
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