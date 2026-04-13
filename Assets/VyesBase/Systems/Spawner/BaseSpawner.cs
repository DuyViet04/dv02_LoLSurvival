using System.Collections.Generic;
using UnityEngine;
using VyesBase.Utils;

namespace VyesBase.Systems.Spawner
{
    public abstract class BaseSpawner : VyesBehaviour
    {
        [SerializeField] private Transform holder;
        [SerializeField] private List<Transform> prefabs;

        private readonly Dictionary<string, Transform> prefabsDict = new();
        private readonly Dictionary<string, Stack<Transform>> poolDict = new();

        protected override void Awake()
        {
            base.Awake();
            InitPrefabsDict();
        }

        private Transform GetObjectFromPool(Transform prefab)
        {
            if (!poolDict.TryGetValue(prefab.name, out Stack<Transform> pool))
            {
                pool = new Stack<Transform>();
                poolDict.Add(prefab.name, pool);
            }

            if (pool.Count > 0)
            {
                return pool.Pop();
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

        private Transform Spawn(Transform prefab, Vector3 position, Quaternion rotation)
        {
            Transform newObj = this.GetObjectFromPool(prefab);
            newObj.SetPositionAndRotation(position, rotation);
            newObj.SetParent(this.holder);
            newObj.gameObject.SetActive(true);
            return newObj;
        }

        public Transform[] Spawn(string prefabName, Vector3 position, Quaternion rotation, int count)
        {
            Transform prefab = GetPrefabByName(prefabName);
            if (prefab == null)
            {
                Debug.LogError(prefabName + " could not be found");
                return null;
            }

            return Spawn(prefab, position, rotation, count);
        }

        protected virtual Transform[] Spawn(Transform prefab, Vector3 position, Quaternion rotation, int count)
        {
            Transform[] newObjs = new Transform[count];

            for (int i = 0; i < count; i++)
            {
                newObjs[i] = Spawn(prefab, position, rotation);
            }

            return newObjs;
        }

        protected virtual Vector3 GetRandomPosition(Vector3 center, float rangeX, float rangeZ)
        {
            float xPos = Random.Range(center.x - rangeX, center.x + rangeX);
            float zPos = Random.Range(center.z - rangeZ, center.z + rangeZ);
            return new Vector3(xPos, center.y, zPos);
        }

        public virtual Transform GetPrefabByName(string prefabName)
        {
            if (prefabsDict.TryGetValue(prefabName, out Transform prefab))
            {
                return prefab;
            }

            return null;
        }

        public virtual void Despawn(Transform obj)
        {
            obj.gameObject.SetActive(false);

            if (!poolDict.TryGetValue(obj.name, out Stack<Transform> pool))
            {
                pool = new Stack<Transform>();
                poolDict.Add(obj.name, pool);
            }

            pool.Push(obj);
        }

        private void InitPrefabsDict()
        {
            foreach (Transform prefab in prefabs)
            {
                if (prefab == null) continue;
                prefabsDict.TryAdd(prefab.name, prefab);
            }
        }

        protected override void LoadComponents()
        {
            base.LoadComponents();
            LoadPrefabs();
            if (holder == null) holder = transform.Find(nameof(SpawnerEnum.Holder));
        }

        private void LoadPrefabs()
        {
            Transform prefabsContainer = transform.Find(nameof(SpawnerEnum.Prefabs));
            if (prefabsContainer == null) return;

            foreach (Transform prefab in prefabsContainer)
            {
                if (prefabs.Contains(prefab)) continue;
                prefabs.Add(prefab);
            }

            HidePrefabs();
        }

        protected virtual void HidePrefabs()
        {
            foreach (Transform prefab in prefabs)
            {
                prefab.gameObject.SetActive(false);
            }
        }
    }
}