using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : SingletonBase<PoolingManager>
{
    [System.Serializable]
    public class PoolConfig
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<PoolConfig> pools;
    private Dictionary<string, ObjectPool> poolDictionary;

    private void Awake()
    {
        InitializePools();
    }

    private void InitializePools()
    {
        poolDictionary = new Dictionary<string, ObjectPool>();

        foreach (var poolConfig in pools)
        {
            GameObject poolObject = new GameObject($"@{poolConfig.tag}_Pool");
            poolObject.transform.SetParent(transform);

            ObjectPool objectPool = poolObject.AddComponent<ObjectPool>();
            objectPool.Initialize(poolConfig.prefab, poolConfig.size);
            
            objectPool.transform.SetParent(poolObject.transform);

            poolDictionary.Add(poolConfig.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning($"Pool with tag {tag} doesn't exist.");
            return null;
        }

        GameObject objectToSpawn = poolDictionary[tag].SpawnFromPool();
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        objectToSpawn.SetActive(true);

        return objectToSpawn;
    }

    public void ReturnToPool(string tag, GameObject obj)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning($"Pool with tag {tag} doesn't exist.");
            return;
        }

        obj.SetActive(false);
        obj.transform.SetParent(poolDictionary[tag].transform);
        poolDictionary[tag].ReturnToPool(obj);
    }
}
