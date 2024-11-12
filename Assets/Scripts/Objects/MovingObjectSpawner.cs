using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MovingObjectSpawner : MonoBehaviour
{
    [SerializeField] private List<string> poolTags;
    [SerializeField] private GameObject[] prefabs;
    private Transform SpawnPoint;    // 스폰 위치
    private bool isRight;           // 방향 확인 플래그, true면 오른쪽에서 스폰
    private float spawnInterval;     // 기본 스폰 쿨탐
    private float spawnProbability;  // 스폰 확률

    private void OnEnable()
    {
        SpawnPoint = transform.GetChild(0);
        
        // 스폰 위치 오브젝트 이름으로 방향 확인
        isRight = SpawnPoint.gameObject.name == "RightSpawnPoint";

        // 기본 값 설정
        spawnInterval = 5.0f;
        spawnProbability = 0.7f;

        SpawnObject();

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
        string randomTag = poolTags[Random.Range(0, poolTags.Count)];
        GameObject spawnedObject = PoolingManager.Instance.SpawnFromPool(randomTag, SpawnPoint.position, Quaternion.identity);

        // 이동할 방향 설정
        float moveDir = isRight ? -1.0f : 1.0f;
        spawnedObject.GetComponent<MovingObject>().Initialize(moveDir);
        
        StartCoroutine(ReturnToPoolAfterDelay(spawnedObject, 10.0f, randomTag));
    }

    private IEnumerator ReturnToPoolAfterDelay(GameObject obj, float delay, string poolTag)
    {
        yield return new WaitForSeconds(delay);
        PoolingManager.Instance.ReturnToPool(poolTag, obj);
    }
}