using System.Collections.Generic;
using UnityEngine;
using VyesBase.Utils;
using VyesBase.Utils.AutoBind;

namespace VyesBase.Systems.Spawner
{
    public abstract class BaseSpawner : VyesBehaviour
    {
        [AutoBind(BindScope.Children, "Holder")]
        [SerializeField] private Transform holder;
        [SerializeField] private List<Transform> prefabs;
        
        private readonly Dictionary<string, Transform> _prefabsDict = new();
        private readonly Dictionary<string, Stack<Transform>> _poolDict = new();

        protected override void Awake()
        {
            base.Awake();
            this.InitPrefabsDict();
        }

        private Transform GetObjectFromPool(Transform prefab)
        {
            if (!_poolDict.TryGetValue(prefab.name, out Stack<Transform> pool))
            {
                pool = new Stack<Transform>();
                _poolDict.Add(prefab.name, pool);
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

        public Transform[] Spawn(string prefabName, Vector3 position, Quaternion rotation, float count)
        {
            Transform prefab = GetPrefabByName(prefabName);
            if (prefab == null)
            {
                Debug.LogError(prefabName + " could not be found");
                return null;
            }

            return Spawn(prefab, position, rotation, count);
        }

        private Transform[] Spawn(Transform prefab, Vector3 position, Quaternion rotation, float count)
        {
            Transform[] newObjs = new Transform[Mathf.RoundToInt(count)];

            for (int i = 0; i < count; i++)
            {
                float xPos = Random.Range(position.x - count * 2f, position.x + count * 2f);
                float zPos = Random.Range(position.z - count * 2f, position.z + count * 2f);
                Vector3 newPos = new Vector3(xPos, position.y, zPos);

                Transform obj = this.GetObjectFromPool(prefab);
                obj.SetPositionAndRotation(newPos, rotation);
                obj.SetParent(this.holder);
                obj.gameObject.SetActive(true);
                newObjs[i] = obj;
            }

            return newObjs;
        }

        private Transform GetPrefabByName(string prefabName)
        {
            if (_prefabsDict.TryGetValue(prefabName, out Transform prefab))
            {
                return prefab;
            }

            foreach (Transform p in prefabs)
            {
                if (p.name == prefabName)
                {
                    return p;
                }
            }

            return null;
        }

        public virtual void Despawn(Transform obj)
        {
            obj.gameObject.SetActive(false);
            
            if (!_poolDict.TryGetValue(obj.name, out Stack<Transform> pool))
            {
                pool = new Stack<Transform>();
                _poolDict.Add(obj.name, pool);
            }
            
            pool.Push(obj);
        }

        private void InitPrefabsDict()
        {
            foreach (Transform prefab in this.prefabs)
            {
                if (prefab == null) continue;
                _prefabsDict.TryAdd(prefab.name, prefab);
            }
        }

        private void LoadPrefabs()
        {
            Transform prefabsContainer = this.transform.Find("Prefabs");
            if (prefabsContainer == null) return;

            foreach (Transform prefab in prefabsContainer)
            {
                if (prefabs.Contains(prefab)) continue;
                prefabs.Add(prefab);
            }

            HidePrefabs();
        }

        void HidePrefabs()
        {
            foreach (Transform prefab in this.prefabs)
            {
                prefab.gameObject.SetActive(false);
            }
        }

        protected override void LoadComponents()
        {
            base.LoadComponents();
            LoadPrefabs();
        }
    }
}