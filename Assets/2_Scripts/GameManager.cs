using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlatformManager platformManager;
    [SerializeField] private Player player;
    [SerializeField] private CamaraManager CamaraManager;

    private void Awake()
    {
        player.Init();
        platformManager.Init();
        CamaraManager.init();
    }

    private void Start()
    {
        platformManager.Active();
    }
}
