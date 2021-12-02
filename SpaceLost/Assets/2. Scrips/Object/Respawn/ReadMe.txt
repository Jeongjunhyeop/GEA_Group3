[리스폰 포인트 사용법]

1. 씬에 [리스폰포인트] 빈 오브젝트 생성 후 RespawnManager 스크립트를 넣는다.
2. 리스폰포인트 오브젝트의 자식으로 RespawnPoint 프리팹을 원하는 만큼 넣는다.
3. 모든 RespawnPoint 오브젝트의 RespawnPointIndex 인스펙터에 0부터 시작하여 번호를 넣는다.
4. RespawnManager 스크립트 인스펙터에 자신이 넣은 만큼의 RespawnPoint 배열을 할당한 뒤 
   모든 RespawnPoint 객체를 번호 순서대로 집어넣는다.(순서가 바뀌면 안됨)