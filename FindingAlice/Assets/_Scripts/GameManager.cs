using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//public enum playerState{
//    idle,
//    Ground_nonClock,
//    Ground_Clock,
//    nonGround_Clock,
//    nonGround_nonClock
//};

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    GameObject option;
    GameObject optionButton;

    //10.12. public으로 수정
    //[SerializeField]
    //bool _patternSwitch = false;

    public bool _patternSwitch = false;
    [SerializeField]
    bool _isGround;

    Vector3 size;

    //playerState _state = playerState.idle;

    float _idleTime = 0f;
    float _patternStartTime = 0f;

    bool isClock = false;

    //Scene에 GameManager가 복수로 존재하는 것 방지
    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
    }

    //플레이어가 플랫폼과 닿았는지 확인
    public bool isGround
    {
        get { return _isGround; }
        set { _isGround = value; }
    }

    //public playerState state{
    //    get { return _state; }
    //    set { _state = value;}
    //}

    public float idleTime
    {
        get { return _idleTime; }
        set { _idleTime = value; }
    }

    public bool patternSwitch
    {
        get { return _patternSwitch; }
        set
        {
            _patternSwitch = value;
            if (_patternSwitch)
                patternStartTime = Time.time;
        }
    }

    public float patternStartTime
    {
        get { return _patternStartTime; }
        set { _patternStartTime = value; }
    }

    private void Start()
    {
        GameObject clockBackEffect = GameObject.Find("ClockBackEffect");
        clockBackEffect.transform.localScale = new Vector3(40000f, 20000f, 0);
        option = GameObject.Find("Option").transform.GetChild(0).gameObject;
        optionButton = GameObject.Find("OptionButton");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Chapter_1");
        }
    }

    public void PopUpOption()
    {
        Time.timeScale = 0;
        optionButton.SetActive(false);
        option.SetActive(true);
    }

    public void PressContinue()
    {
        Time.timeScale = 1;
        option.SetActive(false);
        optionButton.SetActive(true);
    }



    public void PressExitGame()
    {
        GameObject.Find("CollectionManager").GetComponent<CollectionManager>().SaveCollectionData();
        AsyncLoading.LoadScene("SelectChapterScene");
        //SceneManager.LoadScene("SelectChapterScene");
    }
}
