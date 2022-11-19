using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChapter1 : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
            AsyncLoading.LoadScene("Chapter_1");
    }

}