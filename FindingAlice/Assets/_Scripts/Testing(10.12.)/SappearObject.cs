using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SappearObject : MonoBehaviour
{
    //�ش� �θ𿡰� �ε����� �ν������� ������ ���� �Ҵ��� �ڽ��� ������Ʈ���� ������ ��ũ��Ʈ
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
            GameObject.Find(name).transform.Find(someName[i]).gameObject.SetActive(true);
        }
        print("cc");
    }
}
