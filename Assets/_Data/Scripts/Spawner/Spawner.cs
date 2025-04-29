using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform holder;
    [SerializeField] private List<Transform> prefabs;
    [SerializeField] private List<Transform> prefabsPool;
    [SerializeField] private float spawnTime = 1f;
    [SerializeField] private float spawnRange = 5f;
    private float spawnTimer = 0f;

    private void Awake()
    {
        this.LoadPrefabs();
    }

    private void Update()
    {
        this.spawnTimer += Time.deltaTime;
        if (this.spawnTimer < this.spawnTime) return;
        this.spawnTimer = 0f;
        Spawn("Enemy", this.GetRandomPosition(), Quaternion.identity);
    }

    Transform GetObjectFromPool(Transform prefab)
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

    Transform Spawn(string prefabName, Vector3 position, Quaternion rotation)
    {
        Transform prefab = GetPrefabByName(prefabName);
        if (prefab == null)
        {
            Debug.LogError(prefabName + " could not be found");
            return null;
        }

        return Spawn(prefab, position, rotation);
    }

    Transform Spawn(Transform prefab, Vector3 position, Quaternion rotation)
    {
        Transform newObj = this.GetObjectFromPool(prefab);
        newObj.SetPositionAndRotation(position, rotation);
        newObj.SetParent(this.holder);
        newObj.gameObject.SetActive(true);
        return newObj;
    }

    Transform GetPrefabByName(string prefabName)
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

    Vector3 GetRandomPosition()
    {
        float x = Random.Range(this.spawnRange, -this.spawnRange);
        float z = Random.Range(this.spawnRange, -this.spawnRange);
        return new Vector3(x, 0, z);
    }

    void LoadPrefabs()
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