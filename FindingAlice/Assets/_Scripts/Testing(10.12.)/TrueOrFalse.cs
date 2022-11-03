using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueOrFalse : MonoBehaviour
{
    [SerializeField] GameObject[] gameobject;

    int count;

    void Start()
    {
        count = (int)gameobject.LongLength;
        print(count);
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            gameobject[count].SetActive(true);
            gameobject[count-1].SetActive(false);
        }
    }
}