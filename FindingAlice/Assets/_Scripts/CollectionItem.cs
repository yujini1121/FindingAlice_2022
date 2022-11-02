using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionItem : MonoBehaviour
{
    [SerializeField] int number;
    CollectionManager collection_M;

    Vector3 pos;
    float rot = 0;

    private void Start()
    {
        collection_M = GameObject.Find("CollectionManager").GetComponent<CollectionManager>();
        if (collection_M.collection[number])
            gameObject.SetActive(false);
    }

    void Update()
    {
        pos = new Vector3(0, Mathf.Sin(Time.time) * 0.3f, 0);
        rot += Time.deltaTime;

        transform.localPosition = pos;
        transform.localRotation = Quaternion.Euler(new Vector3(0, rot * 30f, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = SoundManager.SM.GetSFX(200);
            audio.Play();
            collection_M.GetItem(number);
            gameObject.SetActive(false);
        }
    }
}
