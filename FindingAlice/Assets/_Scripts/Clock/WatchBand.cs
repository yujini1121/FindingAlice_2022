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
    [SerializeField] Vector3 angle;
    float x = 0f;
    float distance;

    private void Awake()
    {
        clock = player.Find("Clock").transform;
    }

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    private void LateUpdate()
    {
        clockPosition = clock.position;
        playerPosition = player.position;
        Vector3 vec = new Vector3((clockPosition.x + playerPosition.x) / 2, (clockPosition.y + playerPosition.y) / 2, 0);
        transform.position = vec;

        float dx = playerPosition.x - clockPosition.x;
        float dy = playerPosition.y - clockPosition.y;

        angle = new Vector3(0, 0, Mathf.Atan2(dy, dx) * (180f / Mathf.PI));
        transform.rotation = Quaternion.Euler(angle);

        Vector3 scale = new Vector3(Vector3.Distance(clockPosition, playerPosition), 2.4f, 0f);
        transform.localScale = scale;
        if (ClockManager.C.CS == ClockState.shoot)
        {
            x -= Time.deltaTime * 18;
            mat.mainTextureScale = new Vector2(x, 1f);
            distance = Vector2.Distance(clockPosition, playerPosition);
        }
        else if (ClockManager.C.CS == ClockState.shootMaximum)
        {
            x = 0;
        }
        else if (ClockManager.C.CS == ClockState.follow)
        {
            mat.mainTextureOffset = new Vector2(1.05f + x, 0);
            x += Time.deltaTime * 0.8f;
        }
        else
        {
            x = 0;
            mat.mainTextureScale = Vector2.zero;
            mat.mainTextureOffset = new Vector2(1.05f, 0);
        }
    }
}