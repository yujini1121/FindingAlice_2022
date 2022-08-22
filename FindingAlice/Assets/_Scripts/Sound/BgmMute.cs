using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgmMute : MonoBehaviour
{
    Toggle toggle;

    void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.isOn = SoundManager.SM.bgmSoundMute;
        toggle.onValueChanged.AddListener(SoundManager.SM.BgmMute);
    }
}
