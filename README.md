# 프로젝트 소개

길건너 친구들을 할로윈 스타일로 모작한 게임입니다. 플레이어가 다양한 장애물을 피하면서 최대한 많은 Row(행)을 지나가는 것이 목표입니다. 아이템 획득으로 더욱 많은 점수를 획득할 수 있습니다.

### InputSystem

InputSystem Package 활용, 키보드로 조작

- 상좌우 이동:  W, A, D

### PlayGIF
![HighRoWin_DemoPlay](https://github.com/user-attachments/assets/ea8f2121-eac8-4d21-aa5a-0e6a9b826c15)


# 개발 과정

### 개발 환경

- 게임엔진: Unity
- IDE:  Rider

### 개발 기간

2024.11.10 - 2024.11.14 (5일)

# 와이어프레임
![HighRoWin_Diagram](https://github.com/user-attachments/assets/63df7e74-38fc-4b14-8036-0246b02f2b66)


# 과제 가이드 라인을 따른 구현 사항

### 키보드 입력 처리

- InputSystem을 활용, 상좌우 키만 바인딩
- **`PlayerController`**
- Assets/Inputs/PlayerInput

### 오브젝트 동적 생성 및 오브젝트 풀링

- 도로, 움직이지 않는 장애물, 움직이는 장애물, 아이템 동적 생성으로 구현
- 도로는 RePositionManager로 재배치
- 나머지는 PoolingManager 이용해 일정 시간 간격으로 풀링하여 자원 절약
- **`ObjectPool`, `PoolingManager`, `RePositionManager`, `Item`, `ItemSpawner`, `MovingObject`, `MovingObjectSpawner`, `StationaryObjectSpawner`**
- Hierarchy/GameScene/PoolingManager
- Assets/Resources/Prefabs/Roads/Road

### 충돌 기능

- 플레이어 Instance에 Player 태그 설정하여 다른 오브젝트에서 OnTriggerEnter 확인
- 트리거되면 게임오버 이벤트 발생시켜 여러 클래스에서 게임 종료 시 실행해야 할 로직 실행하도록 설계
- **`Item`, `MovingObject`**

### 애니메이션

- Idle, Jump, Die
- Parameter를 Trigger로 설정하여 jump 한번 실행 후 원상태로 자동 복귀
- StringToHash 사용하여 문자열 오타로 인한 오류 방지하고 메모리 절약
- **`AnimationController`, `PlayerAnimationController`**
- Assets/Animation/Skeleton

### 점수 UI 시스템

- W 키 입력되면(전진 시에만) 점수 오르도록 설계
- 아이템 오브젝트에 트리거하면 점수 올라가도록 하고 set 프로퍼티에 이벤트 설정하여 바로 UI 반영
- **`PlayerController`, `Item`, `DataManager`, `UIController`**

### 사운드 효과

- BGM, SFX(점프, 아이템 획득, 장애물 충돌) 플레이 되도록 SoundManager 설계
- **`SoundManager`**

### 파티클 효과

- 파티클 오브젝트에 Player가 OnTriggerEnter 되면 실행되고, OnTriggerExit 되면 중지하도록 구현
- **`ParticleController`**
- Assets/Resources/Prefabs/StationaryObjects/lantern-street-movable-halloween

### Scriptable Object로 데이터 관리

- Item, MovingObject 정보를 Scriptable Object로 통합 관리
- Initialize 시에 SO 기반으로 인스턴스 초기화
- **`ItemSO`, `MovingSO`,** **`Item`, `ItemSpawner`, `MovingObject`, `MovingObjectSpawner`**
- Assets/Scripts/ScriptableObjects/Datas
