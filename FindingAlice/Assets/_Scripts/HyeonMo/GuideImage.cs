using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuideImage : MonoBehaviour
{
    public int childCount = 0;

    //GuideImage 관련 부모 오브젝트에 할당할 것
    [SerializeField] GameObject parentGuideImages;

    //기본적으로 SetActive(false)로 Inspector에서 체크 해제 할 것
    public GameObject[] guideImages;

    [SerializeField] Image[] images;
    [SerializeField] Button[] buttons;

    void Awake()
    {
        parentGuideImages = this.gameObject;

        childCount = parentGuideImages.transform.childCount;

        guideImages = new GameObject[childCount];
        images = new Image[childCount];
        buttons = new Button[childCount];

        //각각 변수에 초기화하여 자식 오브젝트를 건들일 수 있게 반복문 설정
        for (int i = 0; i < childCount; i++)
        {
            Debug.Log("Start(), for문 실행!");
            guideImages[i] = parentGuideImages.transform.GetChild(i).gameObject;

            images[i] = guideImages[i].GetComponent<Image>();
            buttons[i] = guideImages[i].GetComponent<Button>();

            guideImages[i].SetActive(false);
        }
    }

    public void OffImages()
    {
        //자식 오브젝트의 Button 컴포넌트에서 사용됩니다.
        //자신 오브젝트의 - 1번째 오브젝트가 켜지고, 자신 오브젝트가 꺼집니다. 그리고 코루틴이 실행됩니다.
        Debug.Log("OffImages()");
        
        if (childCount == 0)
        {
            guideImages[childCount].SetActive(false);
            return;
        }

        guideImages[childCount - 1].SetActive(true);
        guideImages[childCount].SetActive(false);
        childCount--;
        StartCoroutine(TurnOnGuide());

    }

    public IEnumerator TurnOnGuide()
    {
        //3초 뒤에 버튼이 켜집니다.
        Debug.Log("TurnOnGuide()");
        yield return new WaitForSeconds(3.0f);

        buttons[childCount].enabled = true;
        //nextButtons[childCount] = true;
        //childCount--;
        
        //yield return null;

        //yield break;
    }
}