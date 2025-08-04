using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] private YasuoStats yasuoStats;
    [SerializeField] private Rigidbody playerRigid;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private GameObject tutorial;

    private void Awake()
    {
        this.tutorial.SetActive(true);
    }

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

        if (moveDir != Vector3.zero)
        {
            this.tutorial.SetActive(false);
        }

        this.playerRigid.velocity = moveDir * this.yasuoStats.moveSpeed;
        this.playerAnimator.SetFloat("isRun", this.playerRigid.velocity.magnitude);
    }
}