using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class DataBaseManager : ScriptableObject
{
    public static DataBaseManager Instance;
    public void init()
    {
        Instance = this;

        sfxdataDic = new Dictionary<Define.SFXType, SfxData>();
        foreach (SfxData data in sfxDataArr)
        {
            sfxdataDic.Add(data.sfxType, data);
        }
        bgmdataDic = new Dictionary<Define.BgmType, BgmData>();
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


    [Header("플레이어")]
    [Tooltip("점프를 하면 추가되는 파워")] public float JumpPowerIncrede = 1000; //Player에서 이동
    public float GameOverY = -4.5f; //게임 오버되는 높이
    public float minJumPower = 100f; //최소 점프 파워
    public float maxJumPower = 1000f; //최대 점프 파워
    public float MoveSpeed = 10f; //이동속도

    [Header("아이템")]
    public Item BaseItem;
    public float ItemSpwanper = 0.2f;
    public float ItemBOnus = 0.25f;

    [Header("연출")]
    public Color Scorecolor;
    public Color bonuscolor;
    public float ScorePopInterval = 0.2f;
    public Effect landingEff;

    [Header("플랫폼")]
    public Platform[] LargePlatformArr; //PlatformManager에서 이동
    public Platform[] MiddlePlatformArr;
    public Platform[] SmallPlatformArr;
    public PlatformManager.Data[] DataArr;
    public float GetIntevalMin = 1.0f;
    public float GetIntevalmax = 2.0f;
    public float BounsValue = 0.05f;
    public int RemainPlatformCount = 5;

    [Header("카메라")]
    public float folSpeed = 5; //CameraManager에서 이동

    [Header("사운드")]
    public SfxData[] sfxDataArr;
    public BgmData[] BgmDataArr;
    private Dictionary<Define.SFXType, SfxData> sfxdataDic;
    private Dictionary<Define.BgmType, BgmData> bgmdataDic;


    [System.Serializable] //자식
    public class SfxData : SoundData
    {
        public Define.SFXType sfxType;
    }

    [System.Serializable] //자식
    public class BgmData : SoundData
    {
        public Define.BgmType Bgm;
    }

    [System.Serializable] //부모
    public class SoundData
    {
        public AudioClip clip;
        public float volume = 1;
    }
}
