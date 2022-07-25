using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchBand : MonoBehaviour
{
    public Transform clock;
    public Transform player;
    Material mat;
    Vector3 clockPosition;
    Vector3 playerPosition;
    Vector3 scale;
    [SerializeField] Vector3 angle;
    float x = 0f;

    private void Awake()
    {
        clock = player.Find("Clock").transform;
    }

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        clockPosition = clock.position;
        playerPosition = player.position;
        Vector3 vec = new Vector3((clockPosition.x + playerPosition.x)/2, (clockPosition.y + playerPosition.y)/2, 0);
        transform.position = vec;

        float dx = clockPosition.x - playerPosition.x;
        float dy = clockPosition.y - playerPosition.y;
        angle = new Vector3(0, 0, Mathf.Atan2(dy, dx) * (180f / Mathf.PI));
        transform.rotation = Quaternion.Euler(angle);

        Vector3 scale = new Vector3(Vector3.Distance(clockPosition, playerPosition), 0.3f, 0f);
        transform.localScale = scale;
        if (ClockManager.C.CS == ClockState.shoot)
        {
            x += 0.003f;
            mat.mainTextureScale = new Vector2(x, 1f);
        }
        else
        {
            x = 0;
            mat.mainTextureScale = Vector2.zero;
        }
    }
}
