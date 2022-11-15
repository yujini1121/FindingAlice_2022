using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SappearObject : MonoBehaviour
{
    [SerializeField] GameObject[] someGameobject;

    void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < someGameobject.Length; i++)
            transform.GetChild(i).gameObject.SetActive(true);

        gameObject.GetComponent<Collider>().enabled = false;
    }
}