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
    [Header("�÷��̾�")]
    
    [Tooltip("������ �ϸ� �߰��Ǵ� �Ŀ�")]public float JumpPowerIncrede = 1; //Player���� �̵�

    [Header("�÷���")]
    public Platform[] LargePlatformArr; //PlatformManager���� �̵�
    public Platform[] MiddlePlatformArr;
    public Platform[] SmallPlatformArr;
    public PlatformManager.Data[] DataArr;
    public float GetIntevalMin = 1.0f;
    public float GetIntevalmax = 2.0f;

    [Header("ī�޶�")]
    public float folSpeed = 5; //CameraManager���� �̵�
}
