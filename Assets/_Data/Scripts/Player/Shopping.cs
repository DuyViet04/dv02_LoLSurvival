using UnityEngine;

public class Shopping : VyesBehaviour
{
    // Collider để nhận diện vùng mua sắm
    private void OnTriggerEnter(Collider other)
    {
        Transform parent = other.transform.parent;
        if (parent != null && parent.CompareTag("Shop"))
        {
            ShopManager.Instance.OpenShop(); // Mở giao diện mua sắm khi người chơi vào vùng mua sắm
            ShopSpawner.Instance.Despawn(parent); // Hủy đối tượng vùng mua sắm sau khi mở giao diện
        }
    }
}