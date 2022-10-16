using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Position
{
    left = 0,
    right = 1,


    max
}

public class TalkData
{
    public string name;
    public Sprite sprite;
    public string talkContents;
    public Position position;

    public TalkData(string _name, Sprite _sprite, string tContents, Position p)
    {
        name = _name;
        sprite = _sprite;
        talkContents = tContents;
        position = p;
    }
}

public class TalkManager : MonoBehaviour
{
    Dictionary<int, TalkData[]> talkData;

    Sprite rabbit;
    Sprite tiger;
    Sprite sunbi;
    private void Awake()
    {
        talkData = new Dictionary<int, TalkData[]>();
        rabbit = Resources.LoadAll<Sprite>("토끼_2")[0];
        tiger = Resources.LoadAll<Sprite>("tigerSprite")[0];
        sunbi = Resources.LoadAll<Sprite>("선비_스프라이트")[0];
        GenerateData();
    }

    private void GenerateData() // 데이터 만드는 함수
    {
        TalkData[] a = new TalkData[]
        {
            new TalkData("토끼", rabbit, "윽... 머리야.",Position.left),
            new TalkData("토끼", rabbit, "제대로 온 건가..?", Position.left)
        };
        talkData.Add(1, a);

        TalkData[] b = new TalkData[]
        {
            new TalkData("???", sunbi, "사람 살려!!!",Position.right),
            new TalkData("토끼", rabbit,"무슨 일이 일어나는 거지?", Position.left)
        };
        talkData.Add(2, b);

        TalkData[] c = new TalkData[]
        {
            //new TalkData("호랑이",tiger, "이 녀석! 붙잡히면 가만 안 둔다!!!",Position.right), 호랑이가 뒤에서 쫓아오므로
            new TalkData("호랑이",tiger, "이 녀석! 붙잡히면 가만 안 둔다!!!",Position.left),
            new TalkData("선비", sunbi,"끼야아아악!", Position.right),
            new TalkData("토끼", rabbit,"하하! 선비님, 뒤에 저게 진정 호랑이라는 겁니까요?",Position.left),
            new TalkData("선비", sunbi, "허억.. 헉... 보면 모르시오??",Position.right),
            new TalkData("토끼", rabbit, "제가 호랑이를 실물로 보는 건 처음이라 말이죠..",Position.left),
            new TalkData("선비", sunbi, "근데 토 선생은 왜 같이 뛰는 거시오? 아, 날 구해주려 온 것이군!",Position.right),
            new TalkData("토끼", rabbit, "아뇨, 저도 걸려버렸어요.",Position.left),
            new TalkData("선비", sunbi,"이익..! 당신 뭐야! 구해주려고 온 줄 알았소...",Position.right),
            new TalkData("토끼", rabbit, "앗 아하하하, 농담입니다! 미안하지만 걷어차여도 참으세요!",Position.left),
            new TalkData("선비", sunbi, "지금 무슨 짓을 하려는..",Position.right),
            new TalkData("토끼", rabbit,"지금이야!",Position.left),
            new TalkData("선비", sunbi, "아아아아악!!!",Position.right)
        };
        talkData.Add(3, c);

        TalkData[] d = new TalkData[]
        {
            new TalkData("토끼", rabbit,"그렇게 느린 달리기로 날고 기어봤자 절대 못 잡지~",Position.left),
            new TalkData("호랑이", tiger, "단체로 나를 놀리는군! 잡히기만 해봐라!!",Position.right)
        };
        talkData.Add(4, d);

        TalkData[] e = new TalkData[]
        {
            new TalkData("토끼", rabbit,"선비님! 괜찮으신가요?",Position.left),
            new TalkData("선비", sunbi, "하아.. 걷어차인 곳이 아픈 것 빼고는 괜찮소.",Position.right),
            new TalkData("토끼", rabbit,"하하, 다른 방도가 생각이 안 나서..",Position.left),
            new TalkData("토끼", rabbit,"…, 그런데 왜 쫓기시던 겁니까?",Position.left),
            new TalkData("선비", sunbi, "이야기가 조금 길다만, 잠깐 시간 괜찮소?",Position.right),
            new TalkData("토끼", rabbit,"궁금하군요.", Position.left),
            new TalkData("선비", sunbi, "이 나라에선 오누이네 어머니가 빚은 떡이 일품이라오. 그 떡을 맛보러 조선 팔도에서 모일 정도이지.",Position.right),
            new TalkData("선비", sunbi, "나도 그 떡을 맛보러 매일 들렀지만, 매번 품절이었소.",Position.right),
            new TalkData("선비", sunbi,"그러던 어느 날 일찍 사러 왔지만, 갑자기 호랑이가 나타나더니 떡을 다 가져가버렸소.",Position.right),
            new TalkData("선비", sunbi,"분노에 찬 나머지 나는, 노비에게 녀석이 다시 지나갈 길에 구덩이를 파라고 시켰소.",Position.right),
            new TalkData("토끼", rabbit,"어어, 선비님..?",Position.left),
            new TalkData("선비", sunbi, "그리고 떡을 들고 기뻐하던 녀석은 함정에 빠지게 되었고, 마침 떡만 빼고 빠져버린 녀석을 보며 몇 개 좀 나눠 먹자고 말하고 가져갔지!",Position.right),
            new TalkData("토끼", rabbit, "….",Position.left),
            new TalkData("선비", sunbi, "그 떡은 꿀떡이었소. 내 아직 달떡은 먹어보지 못했으나 달떡 부럽지 않은 그런 맛이었소.", Position.right),
            new TalkData("선비", sunbi, "쩝, 녀석만 쫓아오지 않았다면 더 음미했을 터인데.", Position.right),
            new TalkData("토끼", rabbit,"선비님.. 자기 행동이 정당하다고 생각하세요?", Position.left),
            new TalkData("선비", sunbi, "그런 욕심쟁이 녀석은 당해도 싸오!",Position.right),
            new TalkData("토끼", rabbit, "(이 사람, 뭔가 이상해.)",Position.left),
            new TalkData("토끼", rabbit, "..아 혹시 ‘앨리스’라는 이름을 들어보신 적이 있으신가요?",Position.left),
            new TalkData("선비", sunbi, "거.. 바다 건너엔 그런 이름을 가진 사람이 있다고 들었던 것 같네만.", Position.right),
            new TalkData("선비", sunbi, "가만, 자세히 보니 자네 달 토끼 아닌가? 혹시 가진 달떡..",Position.right),
            new TalkData("토끼", rabbit, "정말 감사합니다!!",Position.left)
        };
        talkData.Add(5, e);

        TalkData[] f = new TalkData[]
        {
            new TalkData("호랑이", tiger, "거기 앞에 토끼, 어디서 많이 보던 얼굴 아닌가?",Position.right),
            new TalkData("토끼", rabbit,"아하하...",Position.left),
            new TalkData("호랑이", tiger,"형이 3초 준다.",Position.right),
            new TalkData("토끼", rabbit, "아까는 오해했습니다, 죄송합니다!",Position.left),
            new TalkData("호랑이", tiger,"3.. 저 토끼 녀석이!!",Position.right),
        };
        talkData.Add(6, f);

        TalkData[] g = new TalkData[]
        {
            new TalkData("호랑이", tiger, "이노오오옴!!", Position.left),
            new TalkData("토끼", rabbit,"바다에는 처음 들어가 본 적이 없지만.. 에라, 모르겠다!",Position.right)
        };
        talkData.Add(7, g);
    }

    public TalkData GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
        {

            return null;
        }
        else
            return talkData[id][talkIndex];
    }
#if false
    public string GameDataFileName = "FindingAlliceData.json";

    public GameData LoadGameData(){
        string filePath = Application.dataPath + "/SaveFile/" + GameDataFileName;

        if(File.Exists(filePath)){
            Debug.Log("Load Succes");
            string FromJsonData = File.ReadAllText(filePath);
            return JsonUtility.FromJson<GameData>(FromJsonData);
        }
        else{
            Debug.Log("Create New File");
            return new GameData();
        }
    }

    public void SaveGameData(){
        string ToJsonData = JsonUtility.ToJson(gameData);
        string filePath = Application.dataPath + "/SaveFile/" + GameDataFileName;

        File.WriteAllText(filePath, ToJsonData);

        Debug.Log("Save Succes");
        Debug.Log("savePoint"+ gameData.playerPosition);
    }
#endif

}