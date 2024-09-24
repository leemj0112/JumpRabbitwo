using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    public Sprite[] backgroundSprites; // ����� ��� ��������Ʈ �迭
    public int objectCount = 10; // ������ ������Ʈ ��
    public float spawnAreaWidth = 10f; // X�� ���� ���� ����
    public float spawnAreaHeight = 10f; // Y�� ���� ���� ����
    public Camera mainCamera; // ī�޶� ����
    public float spawnInterval = 2f; // ��� ������Ʈ ���� ����
    public float minDistanceBetweenObjects = 2f; // ��� ������Ʈ �� �ּ� �Ÿ�

    private List<Vector3> spawnPositions = new List<Vector3>(); // ������ ��ġ ����Ʈ

    void Start()
    {
        StartCoroutine(SpawnBackgroundObjects());
    }

    IEnumerator SpawnBackgroundObjects()
    {
        while (true) // ���� ����
        {
            for (int i = 0; i < objectCount; i++)
            {
                Vector3 cameraPosition = mainCamera.transform.position;
                Vector3 randomPosition;

                do
                {
                    // ���� ��ġ ����
                    randomPosition = new Vector3(
                        cameraPosition.x + Random.Range(-spawnAreaWidth / 2, spawnAreaWidth / 2),
                        cameraPosition.y + Random.Range(-spawnAreaHeight / 2, spawnAreaHeight / 2),
                        0 // Z���� 0���� ����
                    );
                }
                while (IsOverlapping(randomPosition)); // ��ġ�� �ٽ� ����

                // ���� ��������Ʈ ����
                Sprite randomSprite = backgroundSprites[Random.Range(0, backgroundSprites.Length)];

                // ��� ������Ʈ ����
                GameObject backgroundObject = new GameObject("BackgroundObject");
                SpriteRenderer spriteRenderer = backgroundObject.AddComponent<SpriteRenderer>();
                spriteRenderer.sprite = randomSprite;

                // ��ġ ����
                backgroundObject.transform.position = randomPosition;

                // ������ ��ġ ����Ʈ�� �߰�
                spawnPositions.Add(randomPosition);

                // ���� �ð� ���
                yield return new WaitForSeconds(spawnInterval);
            }
        }
    }

    // ��ġ���� üũ�ϴ� �Լ�
    private bool IsOverlapping(Vector3 position)
    {
        foreach (Vector3 existingPosition in spawnPositions)
        {
            if (Vector3.Distance(existingPosition, position) < minDistanceBetweenObjects)
            {
                return true; // ��ġ�� true ��ȯ
            }
        }
        return false; // ��ġ�� ������ false ��ȯ
    }
}