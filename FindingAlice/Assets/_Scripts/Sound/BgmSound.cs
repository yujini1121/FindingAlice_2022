using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmSound : MonoBehaviour
{
    AudioSource _as;

    void Start()
    {
        _as = GetComponent<AudioSource>();
    }


    void Update()
    {
        _as.volume = SoundManager.SM.bgmSoundValue;
        _as.mute = SoundManager.SM.bgmSoundMute;
    }
}
