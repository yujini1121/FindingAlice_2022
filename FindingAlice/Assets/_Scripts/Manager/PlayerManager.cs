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
    [SerializeField] private GameObject gameOverPanel;

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
        CheckGameOver();
    }
    private void Init()
    {
        isGameOver = false;
        // GameObject.FindWithTag("Player").transform.position = lastCPPos;
    }

    private void CheckGameOver()
    {
        if(isGameOver)
        {
            gameOverPanel.SetActive(true);
            // DataController.Instance._gameData.playerPosition = lastCPPos;
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // 체크포인트 부활시 가져올 정보
    public void LoadCheckPoint()
    {
        GameObject.FindWithTag("Player").transform.position =
            DataController.Instance.gameData.playerPosition;
        isGameOver = false;
        gameOverPanel.SetActive(false);
    }
}
