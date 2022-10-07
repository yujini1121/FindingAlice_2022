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

    //private Rigidbody pm_playerRigid;
    //private GameObject pm_player;

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

        //1007
        //pm_player = GameObject.FindGameObjectWithTag("Player");

        ////pm_playerRigid = GameObject.FindGameObjectWithTag("Player");
        ////pm_playerRigid = GetComponentInChildren<PlayerMovement>().playerRigidbody;
        //pm_playerRigid = GetComponentInChildren<PlayerMovement>().playerRigidbody;
    }

    private void Update()
    {
        if(isGameOver)
        {
            //pm_playerRigid.useGravity = true;
            //pm_playerRigid.constraints = RigidbodyConstraints.None;
            //pm_playerRigid.constraints = RigidbodyConstraints.FreezePositionZ;
            //GetComponentInChildren<PlayerMovement>().playerRigidbody.constraints = RigidbodyConstraints.None;
            //GetComponentInChildren<PlayerMovement>().playerRigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
            FadeImage.SetActive(true);
            isGameOver = false;
        }
    }

    private void Init()
    {
        isGameOver = false;
    }


}
