using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter2StartSound : MonoBehaviour
{
    EffectSound SFXSound;
    void Start()
    {
        SFXSound = GameObject.Find("EffectSound").gameObject.GetComponent<EffectSound>();
    }
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			SFXSound.PlaySFX(10000);
		}
	}
}
