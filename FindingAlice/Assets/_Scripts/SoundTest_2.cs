using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTest_1 : MonoBehaviour
{
    BgmSound bgm;

    private void Start()
    {
        bgm = GameObject.Find("Main Camera").GetComponent<BgmSound>();
    }

    private void OnTriggerEnter(Collider other)
    {
        bgm.PlayBGM(6);
    }

    private void OnTriggerExit(Collider collision)
    {
        bgm.PlayBGM(4);
    }
}
