using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoGuide : MonoBehaviour
{
    [SerializeField] Sprite[] sprites = new Sprite[2];

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(SpriteChanging());
    }

    IEnumerator SpriteChanging()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            spriteRenderer.sprite = sprites[1];
            yield return new WaitForSeconds(1.0f);
            spriteRenderer.sprite = sprites[0];

        }
    }
}