using UnityEngine;

public class ShopDespawning : MonoBehaviour
{
    [SerializeField] private float lifeTime = 120f;
    private float timer;

    private void Update()
    {
        this.timer += Time.deltaTime;
        if (this.timer <= this.lifeTime) return;
        this.timer = 0f;
        ShopSpawner.Instance.Despawn(this.transform.parent);
    }
}