using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeText : MonoBehaviour
{
    Text fadeText;

    //Inspector 창에서 입력하려는 문구 
    [SerializeField] string textContents;

    void OnEnable()
    {
        fadeText = this.GetComponent<Text>();
        //StartCoroutine(BlinkText());

        fadeText.text = textContents;
        StartCoroutine(FadeTextToFullAlpha());
    }

    //IEnumerator BlinkText() // 깜빡이는 Text
    //{
    //    while (true)
    //    {
    //        fadeText.text = textContents;
    //        yield return new WaitForSeconds(0.5f);
    //        fadeText.text = " ";
    //        yield return new WaitForSeconds(0.5f);

    //        yield return null;
    //    }
    //}

    IEnumerator FadeTextToFullAlpha() // 알파값 0에서 1로 전환
    {
        fadeText.color = new Color(fadeText.color.r, fadeText.color.g, fadeText.color.b, 0);

        while (fadeText.color.a < 2f)
        {
            fadeText.color =
                new Color(fadeText.color.r, fadeText.color.g, fadeText.color.b,
                fadeText.color.a + (Time.deltaTime / 1.5f));
            //Debug.Log("정상1");
            yield return null;

        }

        StartCoroutine(FadeTextToZero());
        StopCoroutine(FadeTextToFullAlpha());
    }

    IEnumerator FadeTextToZero()  // 알파값 1에서 0으로 전환
    {
        fadeText.color = new Color(fadeText.color.r, fadeText.color.g, fadeText.color.b, 1);

        while (fadeText.color.a > 0.0f)
        {
            fadeText.color =
                new Color(fadeText.color.r, fadeText.color.g, fadeText.color.b,
                fadeText.color.a - (Time.deltaTime / 1.5f));
            //Debug.Log("정상2");
            yield return null;
        }

        StartCoroutine(FadeTextToFullAlpha());
        StopCoroutine(FadeTextToZero());
    }
}