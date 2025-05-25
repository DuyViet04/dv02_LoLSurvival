using System;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class Collecting : VyesBehaviour
{
    [SerializeField] private YasuoStats yasuoStats;
    [SerializeField] private CapsuleCollider pickUpCollider;

    private void FixedUpdate()
    {
        this.pickUpCollider.radius = this.yasuoStats.pickUpRange;
    }

    private void OnTriggerEnter(Collider other)
    {
        Transform parent = other.transform.parent;

        if (parent != null && parent.CompareTag("Item"))
        {
            other.GetComponent<ExpBehaviour>().StartMove();
        }
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadYasuoStats();
        this.LoadPickUpCollider();
    }

    void LoadYasuoStats()
    {
        if (this.yasuoStats != null) return;
        string[] guids = AssetDatabase.FindAssets("t:YasuoStats", new[] { "Assets/_Data/Scripts/Stat/Character/SO" });
        string path = AssetDatabase.GUIDToAssetPath(guids[0]);
        this.yasuoStats = AssetDatabase.LoadAssetAtPath<YasuoStats>(path);
        Debug.LogWarning(this.transform.name + ": LoadYasuoStats", this.gameObject);
    }

    void LoadPickUpCollider()
    {
        if (this.pickUpCollider != null) return;
        this.pickUpCollider = this.GetComponent<CapsuleCollider>();
        Debug.LogWarning(this.transform.name + ": LoadPickUpCollider", this.pickUpCollider);
    }
}