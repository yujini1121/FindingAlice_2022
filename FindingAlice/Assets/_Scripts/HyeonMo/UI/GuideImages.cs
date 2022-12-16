using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuideImages : MonoBehaviour
{
    //각각 자식들을 Inspector 창에서 할당
    [SerializeField] GameObject[] guideImages;

    //각각 Canvas에 있는 것들 할당
    [Header ("Player UI")]
    [SerializeField] GameObject joystick;
    [SerializeField] GameObject joystickLevel;
    [SerializeField] GameObject jumpButton;
    [SerializeField] GameObject clockTouchZone;

    Button[] buttons;

    void Start()
    {
        buttons = new Button[guideImages.Length];

        for (int i = 0; i < guideImages.Length; i++)
        {
            buttons[i] = guideImages[i].GetComponent<Button>();
            buttons[i].interactable = false;
            guideImages[i].transform.GetChild(0).gameObject.SetActive(false);
            guideImages[i].SetActive(false);
        }
    }

    //버튼누르면 이 함수 호출되도록 할 때 쓸 것, guideImages 순서대로 Inspector 창에 index 기입
    public void OnButtonClicked(int index)
    {
        if (index == guideImages.Length - 1)
        {
            guideImages[index].SetActive(false);
            joystick.SetActive(true);
            joystickLevel.SetActive(true);
            jumpButton.SetActive(true);
            clockTouchZone.SetActive(true);
            Destroy(gameObject);
            return;
        }

        // 다음 가이드 이미지를 활성화하고 3초 뒤에 Button 컴포넌트를 활성화
        guideImages[index + 1].SetActive(true);
        StartCoroutine(ActivateButton(index + 1));

        // 현재 가이드 이미지를 비활성화
        guideImages[index].SetActive(false);
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // 첫 번째 가이드 이미지를 활성화하고 3초 뒤에 Button 컴포넌트를 활성화
            guideImages[0].SetActive(true);
            StartCoroutine(ActivateButton(0));

            joystick.SetActive(false);
            joystickLevel.SetActive(false);
            jumpButton.SetActive(false);
            clockTouchZone.SetActive(false);
        }
    }
    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        // 첫 번째 가이드 이미지를 활성화하고 3초 뒤에 Button 컴포넌트를 활성화
    //        guideImages[0].SetActive(true);
    //        StartCoroutine(ActivateButton(0));

    //        joystick.SetActive(false);
    //        joystickLevel.SetActive(false);
    //        jumpButton.SetActive(false);
    //        clockTouchZone.SetActive(false);
    //    }
    //}

    IEnumerator ActivateButton(int index)
    {
        yield return new WaitForSeconds(2.0f);
        buttons[index].interactable = true;
        guideImages[index].transform.GetChild(0).gameObject.SetActive(true);
    }
}