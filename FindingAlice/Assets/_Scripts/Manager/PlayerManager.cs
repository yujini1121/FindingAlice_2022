using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager _instance = null;

    public static PlayerManager Instance()
    {
        return _instance;
    }

    public Vector3 lastCPPos;

    public int pHP;
    private GameObject gameOverPanel;

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
        gameOverPanel = GameObject.Find("GameOverPanel");
    }
    
    private void Update()
    {
        CheckGameOver();
    }
    private void Init()
    {
        pHP = 5;
    }

    private void CheckGameOver()
    {
        if(pHP < 0)
        {
            gameOverPanel.SetActive(true);
        }
    }
}
