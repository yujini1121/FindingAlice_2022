using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager _instance = null;

    public static PlayerManager Instance()
    {
        return _instance;
    }

    public Vector3 lastCPPos = new Vector3(105, 67, 0);

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
            FadeImage.GetComponent<Fade>().FadeInOut();
            isGameOver = false;
            GameObject.FindWithTag("Player").transform.position =
            DataController.Instance.gameData.playerPosition;
            // FadeImage.SetActive(false);
        }
    }

    private void Init()
    {
        isGameOver = false;
    }

//     private void CheckGameOver()
//     {
//         // fade out 은 Update에서 계속 불러주지만 isGameOver가 false가 되면 LoadCheckPoint는 한번만 호출이 되었기 때문.
//         if(isGameOver)
//         {
//             FadeImage.SendMessage("FadeOut");
//             isGameOver = false;
//         }
//         else
//         {
//             return;
//         }
//     }
// public void LoadCheckPoint()
//     {
//         GameObject.FindWithTag("Player").transform.position =
//             DataController.Instance.gameData.playerPosition;
//         isGameOver = false;
//         FadeImage.GetComponent<Fade>().SendMessage("FadeIn");
//         // FadeImage.GetComponent<Fade>().FadeIn();
//         // if(FadeImage.GetComponent<Fade>().endFade)
//         //     FadeImage.SetActive(false);
//     }
}
