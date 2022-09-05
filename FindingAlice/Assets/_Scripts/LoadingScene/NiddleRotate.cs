using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NiddleRotate : MonoBehaviour
{
    [SerializeField] float _timeValue;

    public float timeValue
    {
        get { return _timeValue; }
    }

    void Start()
    {
        InvokeRepeating("Rotate", 0f, 1f);
    }

    void Rotate()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, -timeValue * 30));
        _timeValue++;
    }
}
