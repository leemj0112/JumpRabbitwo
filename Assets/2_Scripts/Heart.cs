using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public void Active(Vector2 pos, float halfsixeX)
    {
        transform.position = pos + new Vector2(Random.Range(-halfsixeX, halfsixeX), 1.4f); //위치 랜덤 생성
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out Player player))
        {
            DataBaseManager.Instance.health++; //체력 1 더하기
            Destroy(gameObject);
            if (DataBaseManager.Instance.health == 3) //만약에 체력이 다 차면
            {
                DataBaseManager.Instance.health = 3;
            }
        }
    }
}
