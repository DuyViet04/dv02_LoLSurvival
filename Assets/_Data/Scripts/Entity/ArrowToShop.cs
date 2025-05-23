using System;
using UnityEngine;

public class ArrowToShop : MonoBehaviour
{
    public Transform shopTransform;
    public Transform playerTransform;

    private void Update()
    {
        Vector3 direction = this.shopTransform.position - this.playerTransform.position;
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        this.transform.parent.rotation = Quaternion.Euler(0, angle, 0);
        this.transform.parent.position =
            new Vector3(this.playerTransform.position.x, 0.5f, this.playerTransform.position.z);

        if (this.shopTransform.gameObject.activeSelf == false)
        {
            ShopSpawner.Instance.Despawn(this.transform.parent);
            return;
        }
    }
}