using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public Transform SpawnPoint;    // 스폰 위치
    private bool isRight;           // 방향 확인 플래그, true면 오른쪽에서 스폰
    public float spawnInterval;     // 기본 스폰 쿨탐
    public float destroyAfter;      // n초 후 오브젝트 삭제
    public float spawnProbability;  // 스폰 확률

    private void Start()
    {
        // 스폰 위치 오브젝트 이름으로 방향 확인
        if (SpawnPoint.gameObject.name == "RightSpawnPoint")
            isRight = true;
        else
            isRight = false;

        // 기본 값 설정
        spawnInterval = 5.0f;
        destroyAfter = 5.0f;
        spawnProbability = 0.7f;
        
        // 스폰 코루틴 실행
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            if (Random.value <= spawnProbability)
            {
                SpawnObject();
            }
        }
    }

    private void SpawnObject()
    {
        // 프리팹 종류 중 하나를 랜덤으로 선택하여 스폰 위치에 생성
        GameObject prefabToSpawn = prefabs[Random.Range(0, prefabs.Length)];
        GameObject spawnedObject = Instantiate(prefabToSpawn, SpawnPoint.position, Quaternion.identity);

        // 이동할 방향 설정
        float moveDir = isRight ? -1.0f : 1.0f;
        spawnedObject.GetComponent<MovingObject>().Initialize(moveDir);

        // n초 후 파괴되도록 설정
        Destroy(spawnedObject, destroyAfter);
    }
}