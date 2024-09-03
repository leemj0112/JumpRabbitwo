using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private AudioSource BgmSource;
    [SerializeField] private AudioSource SfxSoucre;

    public void init()
    {
        instance = this;
    }

    public void PlaySfx(Define.SFXType sfxtype)
    {
        DataBaseManager.SfxData sfxdata = DataBaseManager.Instance.GetSfxclip(sfxtype);
        SfxSoucre.PlayOneShot(sfxdata.clip);
        SfxSoucre.volume = sfxdata.volume;
    }

    public void PlayBgm(Define.BgmType bgmType)
    {
        DataBaseManager.BgmData bgm = DataBaseManager.Instance.GetBgmclip(bgmType);
        BgmSource.clip = bgm.clip;
        BgmSource.volume = bgm.volume;
        BgmSource.Play();
    }
}
