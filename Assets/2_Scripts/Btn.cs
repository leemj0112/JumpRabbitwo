using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Btn : MonoBehaviour
{
   public void MainGO()
    {
        SceneManager.LoadScene("Main"); 
        //게임 화면으로
    }

    public void EndGO()
    {
        Application.Quit();
        //종료 화면으로
    }

    public void StartGO()
    {
        SceneManager.LoadScene("StartScene"); 
        //시작 화면으로
    }


}
