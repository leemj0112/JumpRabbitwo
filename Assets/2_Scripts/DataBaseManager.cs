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


    [Header("플레이어")]
    [Tooltip("점프를 하면 추가되는 파워")] public float JumpPowerIncrede = 1; //Player에서 이동

    [Header("아이템")]
    public Item BaseItem;
    public float ItemSpwanper = 0.2f;
    public float ItemBOnus = 0.25f;

    [Header("연출")]
    public Color Scorecolor;
    public Color bonuscolor;
    public float ScorePopInterval = 0.2f;

    [Header("플랫폼")]
    public Platform[] LargePlatformArr; //PlatformManager에서 이동
    public Platform[] MiddlePlatformArr;
    public Platform[] SmallPlatformArr;
    public PlatformManager.Data[] DataArr;
    public float GetIntevalMin = 1.0f;
    public float GetIntevalmax = 2.0f;
    public float BounsValue = 0.05f;

    [Header("카메라")]
    public float folSpeed = 5; //CameraManager에서 이동

    [Header("사운드")]
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
