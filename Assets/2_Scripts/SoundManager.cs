using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private AudioSource Bgm;
    [SerializeField] private AudioSource Sfx;

    public void init()
    {
        instance = this;
    }

    public void PlaySfx(Define.SFXType sfxtype)
    {
        DataBaseManager.SfxData sfxdata = DataBaseManager.Instance.GetSfxclip(sfxtype);
        Sfx.PlayOneShot(sfxdata.clip);
    }   
}
