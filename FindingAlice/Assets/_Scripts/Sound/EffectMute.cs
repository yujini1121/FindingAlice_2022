using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectMute : MonoBehaviour
{
    Toggle toggle;

    void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.isOn = SoundManager.SM.effectSoundMute;
        toggle.onValueChanged.AddListener(SoundManager.SM.EffectMute);
    }
}
