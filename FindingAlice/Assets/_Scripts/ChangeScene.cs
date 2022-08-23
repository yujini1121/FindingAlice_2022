using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private DataController dCtrl;
    
    private void Awake()
    {
        dCtrl.LoadGameData();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            if(dCtrl._gameData.isClearT)
            {
                SceneManager.LoadScene("SelectChapterScene");
            }
            else
            {
                SceneManager.LoadScene("TutorialScene");
            }
        }
    }
}
