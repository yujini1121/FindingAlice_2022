using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    bool deathCheck = true;
    static int deathCount = -1;

    private static PlayerManager _instance = null;
    public int GetDeathCount()
    {
        return deathCount;
    }

    public static PlayerManager Instance()
    {
        return _instance;
    }

    //public Vector3 lastCPPos = new Vector3(105, 67, 0);

    public bool isGameOver;
    [SerializeField] private GameObject FadeImage; 



    private void Awake()
    {
        Init();

    }

    private void Start()
    {
        if(_instance == null)
        {
            _instance = this;
        }

    }

    private void Update()
    {
        if(isGameOver)
        {
            FadeImage.SetActive(true);
            isGameOver = false;

            //10.12. 죽으면 데스카운터 상승, 어차피 씬 리로드이므로 변수 안 만듬
            //if (deathCheck)
            //{
            //    deathCheck = false;
            //    GameObject.Find("Player").GetComponentInChildren<PlayerMovement>().deathCounter++;
            //    StartCoroutine(Test()); //아직 씬 리로드하는 것이랑 PR 안 되므로 임시용
            //}
        }
    }

    private void Init()
    {
        isGameOver = false;
        deathCount++;
    }


    //IEnumerator Test()
    //{
    //    yield return new WaitForSeconds(0.1f);
    //    deathCheck = true;
    //}


}
