using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    public Sprite[] backgroundSprites; // 사용할 배경 스프라이트 배열
    public int objectCount = 10; // 생성할 오브젝트 수
    public float spawnAreaWidth = 10f; // X축 랜덤 생성 범위
    public float spawnAreaHeight = 10f; // Y축 랜덤 생성 범위
    public Camera mainCamera; // 카메라 참조
    public float spawnInterval = 2f; // 배경 오브젝트 생성 간격
    public float minDistanceBetweenObjects = 2f; // 배경 오브젝트 간 최소 거리

    private List<Vector3> spawnPositions = new List<Vector3>(); // 생성된 위치 리스트

    void Start()
    {
        StartCoroutine(SpawnBackgroundObjects());
    }

    IEnumerator SpawnBackgroundObjects()
    {
        while (true) // 무한 루프
        {
            for (int i = 0; i < objectCount; i++)
            {
                Vector3 cameraPosition = mainCamera.transform.position;
                Vector3 randomPosition;

                do
                {
                    // 랜덤 위치 생성
                    randomPosition = new Vector3(
                        cameraPosition.x + Random.Range(-spawnAreaWidth / 2, spawnAreaWidth / 2),
                        cameraPosition.y + Random.Range(-spawnAreaHeight / 2, spawnAreaHeight / 2),
                        0 // Z축은 0으로 설정
                    );
                }
                while (IsOverlapping(randomPosition)); // 겹치면 다시 생성

                // 랜덤 스프라이트 선택
                Sprite randomSprite = backgroundSprites[Random.Range(0, backgroundSprites.Length)];

                // 배경 오브젝트 생성
                GameObject backgroundObject = new GameObject("BackgroundObject");
                SpriteRenderer spriteRenderer = backgroundObject.AddComponent<SpriteRenderer>();
                spriteRenderer.sprite = randomSprite;

                // 위치 설정
                backgroundObject.transform.position = randomPosition;

                // 생성된 위치 리스트에 추가
                spawnPositions.Add(randomPosition);

                // 일정 시간 대기
                yield return new WaitForSeconds(spawnInterval);
            }
        }
    }

    // 겹치는지 체크하는 함수
    private bool IsOverlapping(Vector3 position)
    {
        foreach (Vector3 existingPosition in spawnPositions)
        {
            if (Vector3.Distance(existingPosition, position) < minDistanceBetweenObjects)
            {
                return true; // 겹치면 true 반환
            }
        }
        return false; // 겹치지 않으면 false 반환
    }
}