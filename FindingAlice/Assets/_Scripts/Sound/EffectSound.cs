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
		_as.mute = SoundManager.SM.bgmSoundMute;
	}

	public void PlaySFX(int key)
	{
		AudioClip audio = SoundManager.SM.GetSFX(key);
		_as.clip = audio;
		_as.Play();
	}
}
