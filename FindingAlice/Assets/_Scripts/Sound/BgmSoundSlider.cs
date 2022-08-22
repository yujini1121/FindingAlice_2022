using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgmSoundSlider : MonoBehaviour
{
    Slider slider;

    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        slider.value = SoundManager.SM.bgmSoundValue;
    }

    void Update()
    {
        SoundManager.SM.bgmSoundValue = slider.value;
        slider.value = Mathf.Round(SoundManager.SM.bgmSoundValue * 4) / 4;
    }
}
