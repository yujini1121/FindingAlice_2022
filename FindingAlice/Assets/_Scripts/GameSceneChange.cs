using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneChange : MonoBehaviour
{   
    static public bool checkLoad = false;
    public void NewGame(){
        // SceneManager.LoadScene("GameScene");
        SceneManager.LoadScene("TempScene");
    }

    public void LoadGame(){
        checkLoad = true;
        // SceneManager.LoadScene("GameScene");
        SceneManager.LoadScene("TempScene");
    }
}
