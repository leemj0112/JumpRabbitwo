using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class DataBaseManager : ScriptableObject
{
    public static DataBaseManager Instance;
    public void init()
    {
        Instance = this;
    }
    [Header("플레이어")]
    
    [Tooltip("점프를 하면 추가되는 파워")]public float JumpPowerIncrede = 1; //Player에서 이동

    [Header("플랫폼")]
    public Platform[] LargePlatformArr; //PlatformManager에서 이동
    public Platform[] MiddlePlatformArr;
    public Platform[] SmallPlatformArr;
    public PlatformManager.Data[] DataArr;
    public float GetIntevalMin = 1.0f;
    public float GetIntevalmax = 2.0f;

    [Header("카메라")]
    public float folSpeed = 5; //CameraManager에서 이동
}
