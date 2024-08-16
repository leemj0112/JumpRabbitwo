using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlatformManager platformManager;
    [SerializeField] private Player player;

    private void Awake()
    {
        player.Init();
        platformManager.Init();
    }

    private void Start()
    {
        platformManager.Active();
    }
}
