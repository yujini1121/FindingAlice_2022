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

    public bool alive;
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
        alive = true;
    }

    private void CheckGameOver()
    {
        if(!alive)
        {
            Debug.Log("Player dead");
            //gameOverPanel.SetActive(true);
        }
    }
}
