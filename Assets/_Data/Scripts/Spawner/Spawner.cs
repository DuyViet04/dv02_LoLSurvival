using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] private Transform holder;
    [SerializeField] private List<Transform> prefabs;
    [SerializeField] private List<Transform> prefabsPool;

    private void Awake()
    {
        this.LoadPrefabs();
    }

    public Transform GetObjectFromPool(Transform prefab)
    {
        foreach (Transform obj in this.prefabsPool)
        {
            if (obj.name == prefab.name)
            {
                this.prefabsPool.Remove(obj);
                return obj;
            }
        }

        Transform newObj = Instantiate(prefab);
        newObj.name = prefab.name;
        return newObj;
    }

    public Transform Spawn(string prefabName, Vector3 position, Quaternion rotation)
    {
        Transform prefab = GetPrefabByName(prefabName);
        if (prefab == null)
        {
            Debug.LogError(prefabName + " could not be found");
            return null;
        }

        return Spawn(prefab, position, rotation);
    }

    protected Transform Spawn(Transform prefab, Vector3 position, Quaternion rotation)
    {
        Transform newObj = this.GetObjectFromPool(prefab);
        newObj.SetPositionAndRotation(position, rotation);
        newObj.SetParent(this.holder);
        newObj.gameObject.SetActive(true);
        return newObj;
    }

    protected Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform prefab in this.prefabs)
        {
            if (prefab.name == prefabName)
            {
                return prefab;
            }
        }

        return null;
    }

    public virtual void Despawn(Transform prefab)
    {
        prefab.gameObject.SetActive(false);
        this.prefabsPool.Add(prefab);
    }

    protected void LoadPrefabs()
    {
        Transform prefabs = this.transform.Find("Prefabs");

        foreach (Transform prefab in prefabs)
        {
            this.prefabs.Add(prefab);
        }

        this.HidePrefabs();
    }

    void HidePrefabs()
    {
        foreach (Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }
}