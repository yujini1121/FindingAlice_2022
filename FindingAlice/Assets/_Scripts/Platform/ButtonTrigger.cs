using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    float x, y, z;
    float transHoldingTime;

    Collider collider;

    void Start()
    {
        x = transform.localScale.x;
        y = transform.localScale.y;
        z = transform.localScale.z;

        transHoldingTime = transform.parent.GetComponentInParent<Transparent>().holdingTime;
        collider = this.gameObject.GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            GetComponentInParent<Transparent>().require = true;
            collider.enabled = false;

            //버튼 충돌 시 방향 전환 및 설정된 시간 후 원방향으로 복귀
            transform.localScale = new Vector3(-x, y, z);

            StopCoroutine(ReturnScale());
            StartCoroutine(ReturnScale());
        }
    }

    IEnumerator ReturnScale()
    {
        yield return new WaitForSeconds(transHoldingTime);
        collider.enabled = true;
        transform.localScale = new Vector3(x, y, z);
    }
}