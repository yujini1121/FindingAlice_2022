using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerPattern : MonoBehaviour
{
    public GameObject pattern;
    public GameObject rock;
    public GameObject claw;

    GameObject player;
    Renderer patternColor;

    int patternValue;
    float patternCooldown = 8f;
    float thisPatternStartTime;
    bool isPattern = false;

    //패턴 1
    int[] pattern1_order = new int[5];
    int pattern1_count;
    float pattern1_time;

    //패턴 2
    float pattern2_launchTime = 3f;
    float pattern2_duration;


    void Start()
    {
        player = GameObject.FindWithTag("Player").gameObject;
        patternColor = pattern.GetComponent<Renderer>();
        pattern.transform.localScale = new Vector3(3, 100, 0);
    }

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x,
                                         this.transform.position.y, this.transform.position.z);

        //외부에서 패턴 실행을 명령할 시 실행 시작
        if (GameManager.instance.patternSwitch)
        {
            if (Time.time - GameManager.instance.patternStartTime > patternCooldown)
            {
                setValue();
                GameManager.instance.patternStartTime += patternCooldown;
            }

            if (isPattern)
            {
                switch (patternValue)
                {
                    //호랑이가 돌 던지는 패턴
                    case 1:
                        Debug.Log("패턴1 실행!");
                        //pattern1_count는 0부터 시작
                        if (Time.time - pattern1_time > pattern1_count)
                        {
                            pattern.transform.position = new Vector3(player.transform.position.x + ((pattern1_order[pattern1_count] - 2) * 3),
                                player.transform.position.y, pattern.transform.position.z);
                            pattern.SetActive(true);
                            StartCoroutine(pattern1_throwStone(pattern.transform.position + new Vector3(0, 50, 0)));
                            pattern1_count++;
                        }
                        if (pattern1_count >= 5)
                        {
                            isPattern = false;
                        }
                        break;

                    //호랑이가 날라가는 패턴
                    case 2:
                        Debug.Log("패턴2 실행!");
                        if (Time.time - thisPatternStartTime < pattern2_launchTime)
                        {
                            pattern2_duration = (Time.time - GameManager.instance.patternStartTime) / pattern2_launchTime;
                            pattern.transform.position = new Vector3(player.transform.position.x,
                                player.transform.position.y, pattern.transform.position.z);
                            patternColor.material.color = new Color(1, 0, 0, Mathf.Lerp(0f, 1f, pattern2_duration));
                        }
                        else
                        {
                            isPattern = false;
                            StartCoroutine(pattern2_claw(pattern.transform.position, pattern.transform.rotation));
                        }
                        break;
                }
            }
        }
    }

    void setValue()
    {
        patternValue = Random.Range(1, 3);
        
        switch (patternValue)
        {
            case 1:
                for (int i = 0; i < 5; i++)
                    pattern1_order[i] = Random.Range(1, 6);

                pattern1_count = 0;
                pattern.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                patternColor.material.color = new Color(1, 0, 0, 0.5f);
                pattern1_time = Time.time;
                break;
            case 2:
                pattern.SetActive(true);
                transform.GetChild(0).gameObject.SetActive(false);
                pattern.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360f)));
                break;
        }

        thisPatternStartTime = Time.time;
        isPattern = true;
    }
    
    IEnumerator pattern1_throwStone(Vector3 vec)
    {
        yield return new WaitForSeconds(0.8f);
        pattern.SetActive(false);
        Instantiate(rock, vec, Quaternion.identity);
    }

    IEnumerator pattern2_claw(Vector3 vec, Quaternion rot)
    {
        yield return new WaitForSeconds(1f);
        pattern.SetActive(false);
        claw.transform.position = new Vector3(vec.x, vec.y, claw.transform.position.z);
        claw.transform.rotation = rot;
        claw.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        claw.SetActive(false);
        transform.GetChild(0).gameObject.SetActive(true);
    }
}