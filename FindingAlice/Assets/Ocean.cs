using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ocean : MonoBehaviour
{
    Material material;
    float iTime;
    Vector4 iDate;
    Vector4 iMouse;

    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        iTime = 0f;
    }

    void Update()
    {
        iTime += Time.deltaTime * 5;
        material.SetFloat("iTime", iTime);

        iDate = new Vector4(2022, 9, 7, iTime);
        material.SetVector("iDate", iDate);

        iMouse = new Vector4(0, 0, 0, 0);
        material.SetVector("iMouse", iMouse);
    }
}
