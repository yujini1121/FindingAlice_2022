using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoGuide_Icon : MonoBehaviour
{
    [SerializeField] Vector3 writeNum;

    void Start()
    {
        StartCoroutine(SpriteChanging());
    }

    IEnumerator SpriteChanging()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            //transform.Translate(new Vector3(0, 1, 0));
            transform.position += writeNum;
            yield return new WaitForSeconds(1.0f);
            //transform.Translate(new Vector3(0, -1, 0));
            transform.position -= writeNum;
        }
    }
}