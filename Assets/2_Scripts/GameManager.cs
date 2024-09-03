using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlatformManager platformManager;
    [SerializeField] private Player player;
    [SerializeField] private CamaraManager CamaraManager;
    [SerializeField] private DataBaseManager dataBaseManager;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private SoundManager soundManager;

    private void Awake()
    {
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
        soundManager.PlayBgm(Define.BgmType.Main);
    }
}
