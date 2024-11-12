using System.Collections;
using UnityEngine;

public class StationaryObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    private float destroyAfter;      // n초 후 오브젝트 삭제
    private float spawnProbability;  // 스폰 확률

    private void OnEnable()
    {
        // 기본 값 설정
        destroyAfter = 60.0f;
        spawnProbability = 0.5f;
        
        if (Random.value <= spawnProbability)
        {
            SpawnObject(transform); // 스크립트 붙어있는 현재 행 기준으로 스폰
        }
    }

    private void SpawnObject(Transform lineTransform)
    {
        // 생성할 오브젝트 종류 랜덤으로 선택
        GameObject prefabToSpawn = prefabs[Random.Range(0, prefabs.Length)];
    
        // 생성할 위치 로컬 좌표 x축 값        
        Vector3 localSpawnPosition = new Vector3(Random.Range(-0.1f, 0.1f), 0, 0);
        // 월드 좌표로 변환    
        Vector3 worldSpawnPosition = lineTransform.TransformPoint(localSpawnPosition);
        
        // 월드 좌표 기준으로 생성
        GameObject spawnedObject = Instantiate(prefabToSpawn, worldSpawnPosition, Quaternion.identity);

        Destroy(spawnedObject, destroyAfter);
    }

}