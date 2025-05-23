using UnityEngine;

public class Despawn : VyesBehaviour
{
    private float lifeTime = 15f;
    private float timer = 0f;

    //Despawn sau 15s
    private void Update()
    {
        this.timer += Time.deltaTime;
        if (this.timer < this.lifeTime) return;
        this.timer = 0f;
        BulletSpawner.Instance.Despawn(this.transform.parent);
    }
}