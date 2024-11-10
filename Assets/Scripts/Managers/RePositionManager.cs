using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RePositionManager : SingletonBase<RePositionManager>
{
    public GameObject roadPrefab;
    public Transform player;
    public float roadSegmentLength = 33f; // 로드 사이의 간격
    
    private List<GameObject> activeRoads = new List<GameObject>();  // 활성화된 로드 프리팹 리스트
    
    private void Start()
    {
        // 2개의 로드가 서로 겹치지 않고 배치되어 생성
        Vector3 firstPosition = player.position;
        Vector3 secondPosition = player.position + Vector3.forward * roadSegmentLength;
        activeRoads.Add(Instantiate(roadPrefab, firstPosition, Quaternion.identity));
        activeRoads.Add(Instantiate(roadPrefab, secondPosition, Quaternion.identity));
    }

    void Update()
    {
        // 플레이어가 하나의 로드를 완전히 지나가면
        if (player.position.z - activeRoads[0].transform.position.z >= roadSegmentLength)
        {
            RepositionRoadSegment();    // 지나간 로드 재배치
        }
    }

    void RepositionRoadSegment()
    {
        // 활성화된 로드 리스트에서 첫번째 요소(지나간 로드) 삭제
        GameObject passedSegment = activeRoads[0];
        activeRoads.RemoveAt(0);

        // 현재 활성화된 로드(플레이어가 지나가고 있는 로드) 기준으로 새로운 위치 잡기
        Vector3 newPosition = activeRoads[0].transform.position + Vector3.forward * roadSegmentLength;
        passedSegment.transform.position = newPosition;

        // 활성화된 로드 리스트에 추가하여 재배치
        activeRoads.Add(passedSegment);
    }
}