using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    float x, y, z;
    float transHoldingTime;

    private void Start()
    {
        x = transform.localScale.x;
        y = transform.localScale.y;
        z = transform.localScale.z;

        transHoldingTime = transform.parent.GetComponentInParent<Transparent>().holdingTime;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            GetComponentInParent<Transparent>().require = true;

            //버튼 충돌 시 방향 전환 및 설정된 시간 후 원방향으로 복귀
            transform.localScale = new Vector3(-x, y, z);
            //StopCoroutine(test());
            CancelInvoke();
            Invoke("ReturnScale", transHoldingTime);
            //StartCoroutine(test());
        }
    }

    public void ReturnScale()
    {
        transform.localScale = new Vector3(x, y, z);
    }

    //IEnumerator test()
    //{
    //    yield return new WaitForSeconds(transHoldingTime);
    //    transform.localScale = new Vector3(x, y, z);
    //}

}