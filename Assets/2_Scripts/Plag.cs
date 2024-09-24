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
        }
    }
}
