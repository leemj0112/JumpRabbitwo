using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Btn : MonoBehaviour
{
   public void MainGO()
    {
        SceneManager.LoadScene("Main"); 
        //���� ȭ������
    }

    public void EndGO()
    {
        Application.Quit();
        //���� ȭ������
    }

    public void StartGO()
    {
        SceneManager.LoadScene("StartScene"); 
        //���� ȭ������
    }


}
