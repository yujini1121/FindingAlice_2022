using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    //페이드 인, 아웃
    // 페이드 인 아웃시 이미지 알파값 조정
    // 코루틴
    private Image fadeImage;
    private float time, fadeTime, start, end;



    private void Init()
    {
        fadeImage = GetComponent<Image>();
        time = 0;
        fadeTime = 1;
        start = 0;
        end = 1;
    }
    
    private void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        StopCoroutine(FadeOutFlow());
        StartCoroutine(FadeOutFlow());
    }    

    private IEnumerator FadeOutFlow()
    {
        time = 0;

        Color color = fadeImage.color;
        while(color.a < end)
        {
            time += Time.deltaTime / fadeTime;
            color.a = Mathf.Lerp(start, end, time);
            fadeImage.color = color;
            yield return null;
        }

        GameObject player;
        Rigidbody playerRigid;

        player = GameObject.FindWithTag("Player");
        playerRigid = player.GetComponent<Rigidbody>();

        player.transform.position = DataController.Instance.gameData.playerPosition;
        time = 0;

        
        playerRigid.constraints = RigidbodyConstraints.None;
        playerRigid.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;

        player.GetComponent<PlayerMovement>().isDie = false;

        while(color.a > start)
        {
            time += Time.deltaTime / fadeTime;
            color.a = Mathf.Lerp(end, start, time);
            fadeImage.color = color;
            yield return null;
        }
        this.gameObject.SetActive(false);

        yield return null;
    }
}
