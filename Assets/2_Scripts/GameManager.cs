using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private PlatformManager platformManager;
    [SerializeField] private Player player;
    [SerializeField] private CamaraManager CamaraManager;
    [SerializeField] private DataBaseManager dataBaseManager;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private GameObject ReBtn;


    public void CallBtnRetry()
    {
        SceneManager.LoadScene(0); //게임 씬 다시 불러오기
    }

    private void Awake()
    {
        Instance = this;
        //순서중요
        dataBaseManager.init();
        player.Init();
        platformManager.Init();
        CamaraManager.init();
        scoreManager.init();
        soundManager.init();
    }

    private void Start()
    {
        platformManager.Active();
        scoreManager.Active();
        soundManager.PlayBgm(Define.BgmType.Main);
    }

    public void OnGameOver()
    {
        ReBtn.SetActive(true);
    }
}
