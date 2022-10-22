using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoGuide : MonoBehaviour
{
    [SerializeField] Sprite[] sprites = new Sprite[2];

    SpriteRenderer spriterenderer;

    void Start()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
    }

    void SpriteChange()
    {

    }

    IEnumerator SpriteChanging()
    {
        yield return new WaitForSeconds(5.0f);
    }

}
