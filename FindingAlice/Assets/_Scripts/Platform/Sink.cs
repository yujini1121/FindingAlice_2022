using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour
{
    public bool checkCollison = false;
    GameObject platform;

    float downVel = 1.5f;
    float upVel;
    float startPosY;
    float currentPosY;

    GameObject player;

    public bool active = false;

    private void Awake(){
        platform = transform.GetChild(0).gameObject;
        startPosY = transform.position.y;
        upVel = downVel * 1.5f;

        player = GameObject.FindWithTag("Player");
    }

    private void Update(){
        currentPosY = transform.position.y;
        SinkFunc();
    }

    private void SinkFunc(){
        if(checkCollison){
            transform.position -= downVel * new Vector3(0,1,0) * Time.deltaTime;
        }
        else{
            UpFunc();    
        }
    }

    private void UpFunc(){
        if(currentPosY < startPosY){
            transform.position += upVel * new Vector3(0,1,0) * Time.deltaTime;
        }
        else{
            transform.position = new Vector3(transform.position.x, currentPosY,transform.position.z);
        }
    }

    private void OnDisable()
    {
        //if (transform.Find("Player").gameObject != null)
        //    player.transform.SetParent(null);
        //player.transform.SetParent(null);
        player.transform.parent = null;
        if (transform.parent.GetComponent<Transparent>().require == false)
        {
            transform.position = new Vector3(transform.position.x, startPosY, transform.position.z);
            checkCollison = false;
            active = false;
        }
    }
}
