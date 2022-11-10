using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SappearObject : MonoBehaviour
{
    //해당 부모에게 부딪히면 인스펙터의 변수에 각각 할당한 자식의 오브젝트들이 켜지는 스크립트
    [SerializeField] GameObject[] someGameobject;
    string[] someName;

    void Start()
    {
        for (int i = 0; i < someGameobject.Length; i++)
        {
            someName[i] = someGameobject[i].name;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < someGameobject.Length; i++)
        {
            GameObject.Find(name).transform.FindChild(someName[i]).gameObject.SetActive(true);
        }
        print("cc");
    }
}
