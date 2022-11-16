using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChapter1 : MonoBehaviour
{
    //GameObject[] cp;

    //void Start()
    //{
    //    cp[0] = GameObject.Find("CP 6");
    //    cp[1] = GameObject.Find("CP 1");
    //}

    //void Update()
    //{
    //    if (cp[0].activeSelf == false)
    //    {
    //        DataController.Instance._gameData.playerPositionTutorial = cp[1].transform.position;
    //        AsyncLoading.LoadScene("Chapter_1");
    //    }

    //}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
            AsyncLoading.LoadScene("SelectChapterScene");
    }

}