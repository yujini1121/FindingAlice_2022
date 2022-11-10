using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObject : MonoBehaviour
{
    [SerializeField] GameObject[] someGameObject;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            for (int i = 0; i < someGameObject.Length; i++)
                transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}