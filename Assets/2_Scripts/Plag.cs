using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Plag : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) //플레이어와 닿으면
    {
        if (collision.transform.TryGetComponent(out Player player))
        {
            SceneManager.LoadScene("EndScene"); //종료 씬 불러오기
            
            //종료되는 순간에 내 점수가 최고 점수보다 많으면 최고 점수를 갱신
            if(DataBaseManager.Instance.tortalScore >= DataBaseManager.Instance.BesrScore)
            {
                DataBaseManager.Instance.BesrScore = DataBaseManager.Instance.tortalScore;
            }
        }
    }
}
