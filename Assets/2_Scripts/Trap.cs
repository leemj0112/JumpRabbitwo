using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public void Active(Vector2 pos, float halfsixeX)
    {
        transform.position = pos + new Vector2(Random.Range(-halfsixeX, halfsixeX), 1.4f); //��ġ ���� ����
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out Player player))
        {
            DataBaseManager.Instance.health--; //ü�� 1 ����
            if (DataBaseManager.Instance.health == 0) //���࿡ ü���� �� ������
            {
                GameManager.Instance.OnGameOver(); //���ӿ��� �Լ�
                GameManager.Instance.PauseGame(); //ȭ�� ���߱� �Լ�
            }
        }
    }
}
