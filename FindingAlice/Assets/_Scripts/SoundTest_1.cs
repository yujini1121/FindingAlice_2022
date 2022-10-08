using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTest_2 : MonoBehaviour
{
    BgmSound bgm;

    private void Start()
    {
        bgm = GameObject.Find("Main Camera").GetComponent<BgmSound>();
    }

    private void OnTriggerEnter(Collider other)
    {
        bgm.PlayBGM(5);
    }

    private void OnTriggerExit(Collider other)
    {
        bgm.PlayBGM(4);
    }
}
