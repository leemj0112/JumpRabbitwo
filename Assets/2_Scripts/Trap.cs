using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public void Active(Vector2 pos, float halfsixeX)
    {
        transform.position = pos + new Vector2(Random.Range(-halfsixeX, halfsixeX), 1.4f); //위치 랜덤 생성
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out Player player))
        {
            DataBaseManager.Instance.health--; //체력 1 빼기
            if (DataBaseManager.Instance.health == 0) //만약에 체력이 다 닳으면
            {
                GameManager.Instance.OnGameOver(); //게임오버 함수
                GameManager.Instance.PauseGame(); //화면 멈추기 함수
            }
        }
    }
}
