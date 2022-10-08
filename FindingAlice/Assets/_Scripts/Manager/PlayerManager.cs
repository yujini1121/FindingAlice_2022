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
            isGameOver = false;
        }
    }

    private void Init()
    {
        isGameOver = false;
    }


}
