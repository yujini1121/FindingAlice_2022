using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSound : MonoBehaviour
{
    AudioSource _as;

    void Start()
    {
        _as = GetComponent<AudioSource>();
    }

    void Update()
    {
        _as.volume = SoundManager.SM.effectSoundValue;
    }
}
