using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulley_Rope : MonoBehaviour
{
    [SerializeField] float rope_Length = 1;
    GameObject rope_L, rope_R;
    Vector3 origin_L, origin_R;

    void Start()
    {
        rope_L = transform.Find("Rope_L").gameObject;
        rope_R = transform.Find("Rope_R").gameObject;
        origin_L = rope_L.transform.localPosition;
        origin_R = rope_R.transform.localPosition;
    }

    void Update()
    {
        rope_L.transform.localScale = new Vector3(rope_L.transform.localScale.x, rope_Length, rope_L.transform.localScale.z);
        rope_R.transform.localScale = new Vector3(rope_R.transform.localScale.x, rope_Length, rope_R.transform.localScale.z);
        rope_L.transform.localPosition = origin_L + new Vector3(0, -rope_Length, 0);
        rope_R.transform.localPosition = origin_R + new Vector3(0, -rope_Length, 0);
    }
}