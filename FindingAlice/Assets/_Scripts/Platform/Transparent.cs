using UnityEngine;

enum Attr
{
    Inst = 0,
    Destroy,
}

public class Transparent : MonoBehaviour
{
    public bool require = false;
    public bool disable = false;
    //[SerializeField] private float holdingTime = 5.0f; 1006 수정, 스위치를 위한 public 선언하게 바꿈
    public float holdingTime = 5.0f;
    private bool isAction = false;

    public int attr;

    public GameObject[] platform;

    private void Start(){
        if (attr == (int)Attr.Inst)
        {
            for (int i = 0; i < platform.Length; i++)
            {
                platform[i].SetActive(false);
            }
        }
    }
    
    private void Update() {
        if (!require)
            return;

        if(attr == (int)Attr.Inst) 
        {
            VisibleFunc();
        }

        if(attr == (int)Attr.Destroy)
        {
            DestroyPlatform();
        }
    }

    void VisibleFunc(){
        for(int i = 0; i < platform.Length; i++){
            platform[i].SetActive(true);
        }
        CancelInvoke();
        Invoke("DestroyPlatform", holdingTime);
        require = false;
    }

    private void DestroyPlatform(){
        for (int i = 0; i < platform.Length; i++){
            if (platform[i].gameObject.activeSelf == false)
                break;
            platform[i].SetActive(false);
        }
    }
}