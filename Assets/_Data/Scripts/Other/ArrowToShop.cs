using UnityEngine;

public class ArrowToShop : MonoBehaviour
{
    public Transform shopTransform;
    public GameObject player;

    private void Update()
    {
        //Tính toán hướng từ shop đến player
        Vector3 direction = this.shopTransform.position - this.player.transform.position;
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        //Gán góc quay và vị trí của mũi tên
        this.transform.parent.rotation = Quaternion.Euler(0, angle, 0);
        this.transform.parent.position =
            new Vector3(this.player.transform.position.x, 0.5f, this.player.transform.position.z);

        //Despawn mũi tên nếu shop despawn
        if (this.shopTransform.gameObject.activeSelf == false)
        {
            ShopSpawner.Instance.Despawn(this.transform.parent);
            return;
        }
    }
}