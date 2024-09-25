using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Plag : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) //�÷��̾�� ������
    {
        if (collision.transform.TryGetComponent(out Player player))
        {
            SceneManager.LoadScene("EndScene"); //���� �� �ҷ�����
            
            //����Ǵ� ������ �� ������ �ְ� �������� ������ �ְ� ������ ����
            if(DataBaseManager.Instance.tortalScore >= DataBaseManager.Instance.BesrScore)
            {
                DataBaseManager.Instance.BesrScore = DataBaseManager.Instance.tortalScore;
            }
        }
    }
}
