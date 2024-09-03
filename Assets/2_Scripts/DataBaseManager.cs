using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class DataBaseManager : ScriptableObject
{
    public static DataBaseManager Instance;
    public void init()
    {
        Instance = this;

        foreach(SfxData data in sfxDataArr)
        {
            sfxdataDic.Add(data.sfxType, data);
        }
    }

    public SfxData GetSfxclip(Define.SFXType Type)
    {
        return sfxdataDic[Type];
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
    private Dictionary<Define.SFXType, SfxData> sfxdataDic = new Dictionary<Define.SFXType, SfxData>();

    [System.Serializable]
    public class SfxData
    {
        public Define.SFXType sfxType;
        public AudioClip clip;
    }

    [System.Serializable]
    public class BGM
    {
        public Define.BgmType Bgm;
        public AudioClip clip;
    }
}
