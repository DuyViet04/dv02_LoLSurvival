using UnityEngine;

public class ArrowDespawning : VyesBehaviour
{
    [SerializeField] private float lifeTime = 120f;
    [SerializeField] private SpriteRenderer arrowRenderer;
    private float timer;

    private void Update()
    {
        this.timer += Time.deltaTime;
        float t = (this.lifeTime - this.timer) / this.lifeTime;

        var color = this.arrowRenderer.color;
        color.a = t;
        this.arrowRenderer.color = color;

        if (this.timer <= this.lifeTime) return;
        this.timer = 0f;
        ShopSpawner.Instance.Despawn(this.transform.parent);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadArrowRenderer();
    }

    void LoadArrowRenderer()
    {
        if (this.arrowRenderer != null) return;
        this.arrowRenderer = this.transform.parent.GetComponentInChildren<SpriteRenderer>();
        Debug.LogWarning(this.transform.name + ": LoadArrowRenderer", this.gameObject);
        ;
    }
}