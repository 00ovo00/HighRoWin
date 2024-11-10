using System.Collections;
using UnityEngine;

public class StationaryObjectSpawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public float destroyAfter;      // n초 후 오브젝트 삭제
    public float spawnProbability;  // 스폰 확률

    private void OnEnable()
    {
        // 기본 값 설정
        destroyAfter = 60.0f;
        spawnProbability = 0.5f;
        
        if (Random.value <= spawnProbability)
        {
            SpawnObject(transform);
        }
    }

    private void SpawnObject(Transform lineTransform)
    {
        // Select a random prefab
        GameObject prefabToSpawn = prefabs[Random.Range(0, prefabs.Length)];
    
        // Generate a random local x position between -1.0 and 1.0 relative to the line
        
        Vector3 localSpawnPosition = new Vector3(Random.Range(-0.1f, 0.1f), 0, 0);
    
        // Convert the local position to a world position based on the line’s transform
        Vector3 worldSpawnPosition = lineTransform.TransformPoint(localSpawnPosition);
    
        // Instantiate the object at the calculated world position
        GameObject spawnedObject = Instantiate(prefabToSpawn, worldSpawnPosition, Quaternion.identity);

        // Destroy the object after a set time
        Destroy(spawnedObject, destroyAfter);
    }

}