using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AsyncLoading : MonoBehaviour
{
    //비동기 로딩씬

    public static string nextScene;
    [SerializeField] Image progressBar;
    [SerializeField] GameObject minute;
    [SerializeField] Text text;
    NiddleRotate nr;

    [SerializeField] string[] loadingText;

    int attr;

    void Start()
    {
        Time.timeScale = 1f;
        nr = minute.GetComponent<NiddleRotate>();
        FillText();
        text.text = loadingText[Random.Range(0, 13)];
        StartCoroutine(LoadScene());
    }

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        while (!op.isDone)
        {
            yield return null;
            if (op.progress >= 0.9f && nr.changeSceneFlag)
            {
                op.allowSceneActivation = true;
                yield break;
            }
        }
    }

    void FillText()
    {
        loadingText[0] = "간을 바치고 용왕의 신하가 된 생물들이 있습니다.\n해마, 바다코끼리 등이 그렇습니다.";
        loadingText[1] = "바다에는 해류라고 불리는 바닷길이 있습니다.\n거센 바닷길은 용왕의 허락 없이는 지나갈 수 없습니다.";
        loadingText[2] = "선대 용왕의 아내는 인당수의 심청이었다고 합니다.";
        loadingText[3] = "거북이가 토끼를 이긴 후 거북이 가문은 대대로 무관직에 올랐습니다.";
        loadingText[4] = "하트 가문의 사람들은 태어날 때부터 일정한 능력을 타고납니다.\n그리고 능력의 수준에 따라 ‘폰’, ‘룩’, ‘나이트’, ‘비숍’, ‘퀸’의 칭호를 부여받습니다.";
        loadingText[5] = "오직 ‘퀸’만이 여왕의 자리에 오를 자격이 주어집니다.";
        loadingText[6] = "체스에서 ‘폰’은 가장 단순한 말이지만,\n체스판 끝까지 전진하면 ‘퀸’이 될 수 있습니다.";
        loadingText[7] = "하트 가문은 원래 버섯이 특산품이었으나 관리가 이루어지지 않아 거대한 버섯 숲이 되었습니다.";
        loadingText[8] = "어쩌면, 인생에서 타고나는 건 중요할 수 있습니다.\n자신이 타고난 것을 깨닫는 것은 다른 문제지만요.";
        loadingText[9] = "토끼가 등장하는 동화들은 토끼들에게 언제나 베스트셀러이다.";
        loadingText[10] = "달에는 토끼들만 모여서 산다. 성공한 토끼들은 1년 중 지구와 달이 가까워졌을 때 지구로 넘어간다.";
        loadingText[11] = "달 토끼가 빚은 달떡은 모든 생물이 좋아하는 달의 특산품이다.";
        loadingText[12] = "달 토끼의 달떡은 지구에서 가장 많이 팔린다.";
    }
}