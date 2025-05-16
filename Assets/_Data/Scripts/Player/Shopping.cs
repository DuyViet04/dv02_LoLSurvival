using UnityEngine;

public class Shopping : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Transform parent = other.transform.parent;
        if (parent != null && parent.CompareTag("Shop"))
        {
            ShopManager.Instance.OpenShop();
        }
    }
}