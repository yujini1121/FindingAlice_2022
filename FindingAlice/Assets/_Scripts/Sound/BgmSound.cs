using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmSound : MonoBehaviour
{
    AudioSource _as;

	void Awake()
	{
		if(gameObject.name == "BGMPlayer")
			DontDestroyOnLoad(gameObject);
	}

	void Start()
    {
        _as = GetComponent<AudioSource>();
        _as.Play();
    }

    void Update()
    {
        _as.volume = SoundManager.SM.bgmSoundValue;
        _as.mute = SoundManager.SM.bgmSoundMute;
    }

    public void PlayBGM(int key)
    {
        AudioClip audio = SoundManager.SM.GetBGM(key);
        _as.clip = audio;
        _as.Play();
    }
}
