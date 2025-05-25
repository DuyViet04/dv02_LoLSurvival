using UnityEngine;

public class Shopping : VyesBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Transform parent = other.transform.parent;
        if (parent != null && parent.CompareTag("Shop"))
        {
            ShopManager.Instance.OpenShop();
            ShopSpawner.Instance.Despawn(parent);
        }
    }
}