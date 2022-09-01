using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgmSoundSlider : MonoBehaviour
{
    Slider slider;
    private void Awake()
    {
        //SoundManager.SM.bgmSoundValue;
        slider = gameObject.GetComponent<Slider>();
        slider.value = SoundManager.SM.bgmSoundValue;
    }

#if false
    void Start()
    {

    }
#endif

    void Update()
    {
        SoundManager.SM.bgmSoundValue = slider.value;
        slider.value = Mathf.Round(SoundManager.SM.bgmSoundValue * 4) / 4;
    }
}
