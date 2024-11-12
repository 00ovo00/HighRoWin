using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private Queue<GameObject> objectPool;
    private GameObject prefab;

    public void Initialize(GameObject prefab, int size)
    {
        this.prefab = prefab;
        objectPool = new Queue<GameObject>();

        for (int i = 0; i < size; i++)
        {
            GameObject obj = Instantiate(prefab, transform);
            obj.SetActive(false);
            objectPool.Enqueue(obj);
        }
    }

    public GameObject SpawnFromPool()
    {
        if (objectPool.Count == 0)
        {
            Debug.LogWarning("ObjectPool is empty!");
            return null;
        }

        GameObject obj = objectPool.Dequeue();
        objectPool.Enqueue(obj);
        return obj;
    }

    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.SetParent(transform);
    }
}