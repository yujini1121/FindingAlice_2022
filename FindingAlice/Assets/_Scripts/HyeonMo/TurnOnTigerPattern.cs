using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnTigerPattern : MonoBehaviour
{
    [SerializeField] bool patternOn = false;

    [SerializeField] GameObject tigerBackGround;
    TigerPattern tigerPattern;

    GameObject mainCamera;
    AudioSource mcAudioSource;
    BgmSound bgmSound;

    Collider collider;

    void Start()
    {
        tigerPattern = gameObject.GetComponent<TigerPattern>();
        collider = this.gameObject.GetComponent<Collider>();

        mainCamera = GameObject.Find("Main Camera");
        mcAudioSource = mainCamera.GetComponent<AudioSource>();
		bgmSound = mainCamera.GetComponent<BgmSound>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (patternOn)
            {
                tigerBackGround.SetActive(true);
                if(mcAudioSource.clip != SoundManager.SM.GetBGM(4000))
                    bgmSound.PlayBGM(4000);
            }
                
            else if (!patternOn)
            {
                tigerBackGround.SetActive(false);
                if (GameObject.FindWithTag("TigerClaw") != null)
                {
                    GameObject.FindWithTag("TigerClaw").gameObject.SetActive(false);
                }
                else if(GameObject.FindWithTag("TigerPattern") != null)
				{
					GameObject.FindWithTag("TigerPattern").gameObject.SetActive(false);
				}
                bgmSound.PlayBGM(3000);
			}
            this.gameObject.SetActive(false);
        }
    }
}