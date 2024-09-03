using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class DataBaseManager : ScriptableObject
{
    public static DataBaseManager Instance;
    public void init()
    {
        Instance = this;

        foreach (SfxData data in sfxDataArr)
        {
            sfxdataDic.Add(data.sfxType, data);
        }
        foreach (BgmData data in BgmDataArr)
        {
            bgmdataDic.Add(data.Bgm, data);
        }
    }

    public SfxData GetSfxclip(Define.SFXType Type)
    {
        return sfxdataDic[Type];
    }
    public BgmData GetBgmclip(Define.BgmType Type)
    {
        return bgmdataDic[Type];
    }


    [Header("�÷��̾�")]
    [Tooltip("������ �ϸ� �߰��Ǵ� �Ŀ�")] public float JumpPowerIncrede = 1; //Player���� �̵�

    [Header("������")]
    public Item BaseItem;
    public float ItemSpwanper = 0.2f;
    public float ItemBOnus = 0.25f;

    [Header("����")]
    public Color Scorecolor;
    public Color bonuscolor;
    public float ScorePopInterval = 0.2f;

    [Header("�÷���")]
    public Platform[] LargePlatformArr; //PlatformManager���� �̵�
    public Platform[] MiddlePlatformArr;
    public Platform[] SmallPlatformArr;
    public PlatformManager.Data[] DataArr;
    public float GetIntevalMin = 1.0f;
    public float GetIntevalmax = 2.0f;
    public float BounsValue = 0.05f;

    [Header("ī�޶�")]
    public float folSpeed = 5; //CameraManager���� �̵�

    [Header("����")]
    public SfxData[] sfxDataArr;
    public BgmData[] BgmDataArr;
    private Dictionary<Define.SFXType, SfxData> sfxdataDic = new Dictionary<Define.SFXType, SfxData>();
    private Dictionary<Define.BgmType, BgmData> bgmdataDic = new Dictionary<Define.BgmType, BgmData>();


    [System.Serializable] //�ڽ�
    public class SfxData : SoundData
    {
        public Define.SFXType sfxType;
    }

    [System.Serializable] //�ڽ�
    public class BgmData : SoundData
    {
        public Define.BgmType Bgm;
    }

    [System.Serializable] //�θ�
    public class SoundData
    {
        public AudioClip clip;
        public float volume = 1;
    }
}
