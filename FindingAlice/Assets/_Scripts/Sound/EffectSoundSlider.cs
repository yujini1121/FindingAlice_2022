using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectSoundSlider : MonoBehaviour
{
    Slider slider;

    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        slider.value = SoundManager.SM.effectSoundValue;
    }

    void Update()
    {
        SoundManager.SM.effectSoundValue = slider.value;
        slider.value = Mathf.Round(SoundManager.SM.effectSoundValue * 4) / 4;
    }
}
