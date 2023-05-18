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
    Sprite parentRabbit;
    Sprite tiger;
    Sprite sunbi;

    Sprite servant;
    Sprite turtle;
    Sprite dragonKing;

    Sprite none;


    private void Awake()
    {
        talkData = new Dictionary<int, TalkData[]>();
        rabbit = Resources.LoadAll<Sprite>("토끼_2")[0];
        parentRabbit = Resources.Load<Sprite>("ParentRabbit");
        tiger = Resources.LoadAll<Sprite>("Tiger")[0];
        sunbi = Resources.LoadAll<Sprite>("선비_스프라이트")[0];
        none = null;
        GenerateData();
    }

    private void GenerateData() // 데이터 만드는 함수
    {
        //a~g까지 챕터1 스토리
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
            new TalkData("호랑이", tiger,"3.. 저 토끼 녀석이!!",Position.right)
        };
        talkData.Add(6, f);

        TalkData[] g = new TalkData[]
        {
            new TalkData("호랑이", tiger, "이노오오옴!!", Position.left),
            new TalkData("토끼", rabbit,"바다에는 처음 들어가 본 적이 없지만.. 에라, 모르겠다!",Position.right)
        };
        talkData.Add(7, g);


        //h~m까지 튜토리얼 스토리 및 가이드 대사
        //h는 초반 스토리
        TalkData[] h = new TalkData[]
        {
            new TalkData("토끼", rabbit, "",Position.left),
        };
        talkData.Add(8, h);

        TalkData[] i = new TalkData[]
        {
            new TalkData("토끼", rabbit, "역시 아침 공기는 상쾌해.",Position.left),
            new TalkData("토끼", rabbit, "부모님이 걱정되지만 내가 집으로 돌아가도 바뀌는 게 하나도 없어.",Position.left),
            new TalkData("토끼", rabbit, "그렇다면 앨리스를 찾아서 보여드리겠어... 나도 동화 속 시계 토끼처럼... 할 수 있다는 것을!",Position.left)
        };
        talkData.Add(9, i);

        TalkData[] k = new TalkData[]
        {
            new TalkData("토끼", rabbit, "저 절벽은 생각보다 높아보이네?",Position.left),
            new TalkData("토끼", rabbit, "이 시계를 사용하면 넘어갈 수 있지 않을까?",Position.left)
        };
        talkData.Add(10, k);

        TalkData[] l = new TalkData[]
        {
            new TalkData("토끼", rabbit, "뭔가 아무것도 보이지 않아..", Position.left),
            new TalkData("토끼", rabbit, "아래로 숙여볼까?", Position.left)
        };
        talkData.Add(11, l);

        TalkData[] m = new TalkData[]
        {
            new TalkData("토끼", rabbit, "얼마나 걸었을까? 더이상 집도, 앨리스도 보이지 않아..", Position.left),
            new TalkData("토끼", rabbit, "이제 찾을 곳은 지구 밖에 없어.", Position.left),
            new TalkData("토끼", rabbit, "앨리스를 찾으러 지구로 가보자.", Position.left)
        };
        talkData.Add(12, m);

        // 튜토리얼 전 대화
        TalkData[] ta = new TalkData[]
        {
            new TalkData("", none, "달 속 토끼가 아침부터 세수를 하며 동화책을 손에 들고 있다.", Position.left),
            new TalkData("", none, "침대 위에 앉아 동화책을 한 장 한 장 넘기면서 토끼는 입가에 미소가 생긴다.", Position.left),
            new TalkData("토끼", rabbit, "내가 좋아하는 동화는 이상한 나라의 앨리스야.", Position.left),
            new TalkData("토끼", rabbit, "하지만 나는 달 토끼라서 동화에 나오는 시계 토끼처럼 살 수가 없어.", Position.left),
            new TalkData("토끼", rabbit, "그런 지겨운 삶을 살 바에는... 나중에 부모님께 설득해 봐야지!", Position.left),
        };
        talkData.Add(13, ta);

        TalkData[] tb = new TalkData[]
        {
            new TalkData("아버지 토끼", parentRabbit, "오늘은 학교에 가지 않아도 된단다.", Position.right),
            new TalkData("토끼", rabbit, "네???", Position.left),
            new TalkData("아버지 토끼", parentRabbit, "너도 이제부터 제대로 일을 배워야 하지 않겠니?", Position.right),
            new TalkData("토끼", rabbit, "저는...", Position.left),
            new TalkData("어머니 토끼", parentRabbit, "우리 달 토끼는 달떡을 만드는 게 삶의 목표이자 일이란다.", Position.right),
            new TalkData("토끼", rabbit, "일이라뇨?? 전 싫다고 말씀드렸잖아요!", Position.left),
            new TalkData("어머니 토끼", parentRabbit, "아까도 말했잖니, 우리는 달 토...", Position.right),
            new TalkData("토끼", rabbit, "달 토끼, 달 토끼... 정말 지긋지긋하다고요!", Position.left),
            new TalkData("토끼", rabbit, "전 정말 하기 싫어요. 제가 하고 싶은 건 그런 게 아닐뿐더러 부모님처럼 살기 싫다고...", Position.left),
            new TalkData("아버지 토끼", parentRabbit, "나가라.", Position.right),
            new TalkData("토끼", rabbit, "네... 죄송합니다.", Position.left),
        };
        talkData.Add(14, tb);

        TalkData[] tD = new TalkData[]
        {
            new TalkData("토끼", rabbit, "이쪽이 아니라 반대편으로 가야해.", Position.left),
        };
        talkData.Add(100, tD);


        // o~t까지 챕터2 스토리
        TalkData[] o = new TalkData[]
        {
            new TalkData("토끼", rabbit, "숨을 쉬기 어려워..", Position.left),
            new TalkData("토끼", rabbit, "식물을 이용해서 산소를 공급할 수 있지 않을까?", Position.left)
        };
        talkData.Add(15, o);

        TalkData[] p = new TalkData[]
        {
            new TalkData("토끼", rabbit, "아까부터 제자리야. 바다가 나를 막고 있어...", Position.left),
            new TalkData("토끼", rabbit, "이곳을 지나야 하는데... 다른 길이 있을까?", Position.left),
        };
        talkData.Add(16, p);

        TalkData[] q = new TalkData[]
        {
            new TalkData("거북이", turtle, "이곳에 무슨 일이십니까!", Position.right),
            new TalkData("토끼", rabbit, "이곳을 건너가려 합니다.", Position.left),
            new TalkData("거북이", turtle, "여기는 용왕님의 허락 없이는 지나갈 수 없습니다.", Position.right),
            new TalkData("토끼", rabbit, "그럼.. 허락을 받으려면 어떻게 해야 하죠?", Position.left),
            new TalkData("거북이", turtle, "용왕님을 뵈려거든 제 등에 타시지요.", Position.right)
        };
        talkData.Add(17, q);

        // 장소 이동 -> 용궁
        TalkData[] r = new TalkData[]
        {
            new TalkData("신하", servant, "동해 수사(동해의 수군절도사)가 알현을 요청합니다.", Position.right),
            new TalkData("용왕", dragonKing, "들라 하라.", Position.right),
            new TalkData("거북이", turtle, "바다의 아버지를 뵙습니다.", Position.right),
            new TalkData("용왕", dragonKing, "자네는 국경을 지키고 있을 터인데, 무슨 일인가?", Position.right),
            new TalkData("거북이", turtle, "동해에서 서해로 가는 바닷길을 건너고자 하는 자가 있어 데려왔습니다.", Position.right),
            new TalkData("용왕", dragonKing, "아니 이거 토선생 아닌가! 이 깊은 바다에는 어인 일로 오셨소?", Position.right),
            new TalkData("토끼", rabbit, "저는 바다를 건너야 합니다. 하지만 바닷길에 막혀 통행을 허락받고자 찾아뵈었습니다.", Position.left),
            new TalkData("용왕", dragonKing, "허허, 바닷길은 내가 열어줄 수 있소.", Position.right),
            new TalkData("용왕", dragonKing, "대신 내가 육지의 생물을 보는 게 오랜만이란 말이지..", Position.right),
            new TalkData("용왕", dragonKing, "나와 내기를 해서 이기면 내, 바닷길을 열어주겠소.", Position.right),
            new TalkData("토끼", rabbit, "그럼, 만약 제가 지면 어떻게 되는 건가요?", Position.left),
            new TalkData("용왕", dragonKing, "토선생께서 지게 되면 토선생의 간을 바치고 나의 신하가 되는 거요. 어떻소?", Position.right),
            new TalkData("토끼", rabbit, "좋습니다. 종목은 어떻게 되죠?", Position.left),
            new TalkData("용왕", dragonKing, "달리기 시합이오! 먼 옛날, 육상에선 거북이가 토끼를 이겼지 않소? 바다에서 겨루면 어떻게 될지 궁금해서 말이지!", Position.right),
            new TalkData("토끼", rabbit, "그럼, 제 상대는...?", Position.left),
            new TalkData("거북이", turtle, "한 수 부탁드리겠습니다. 정정당당하게 겨뤄보지요.", Position.right),
            new TalkData("토끼", rabbit, "(바다에서 정정당당한 승부가 맞나?)", Position.left)
        };
        talkData.Add(18, r);

        // 1차 타임 어택
        TalkData[] s = new TalkData[]
        {
            new TalkData("토끼", rabbit, "정말 힘든 달리기였어...", Position.left),
            new TalkData("거북이", turtle, "좋은 승부였습니다.", Position.right),
            new TalkData("용왕", dragonKing, "굉장히 날쌔시구려.", Position.right),
            new TalkData("용왕", dragonKing, "바닷길은 열렸소. 건너가도 좋소이다.", Position.right),
            new TalkData("용왕", dragonKing, "마지막으로 묻겠소. 나의 신하가 될 생각은 없소?", Position.right),
            new TalkData("토끼", rabbit, "이루고자 하는 것이 있어서요. 길을 열어주셔서 감사합니다.", Position.left),
            new TalkData("용왕", dragonKing, "뜻이 그렇다면 어쩔 수 없지.", Position.right),
            new TalkData("용왕", dragonKing, "잡아라.", Position.right),
            new TalkData("토끼", rabbit, "네? 달리기 시합에서 이기면 길을 열어주신다고..?", Position.left),
            new TalkData("용왕", dragonKing, "나는 길을 열어주겠다고 했지, 보내주겠다고는 하지 않았소.", Position.right),
            new TalkData("토끼", rabbit, "그런 억지스러운...", Position.left),
            new TalkData("거북이", turtle, "용왕님, 이건 옳지 않습니다! 토선생, 도망치시오!", Position.right)
        };
        talkData.Add(19, s);

        // 장애물 기믹 시작 
        TalkData[] t = new TalkData[]
        {
            new TalkData("토끼", rabbit, "거북이의 도움으로 뒤따라오던 병사들이 안 보여.", Position.left),
            new TalkData("토끼", rabbit, "조금만 가면 앨리스를 만날 수 있어.", Position.left),
            new TalkData("토끼", rabbit, "하지만 체력의 한계가...", Position.left),
            new TalkData("토끼", rabbit, "......", Position.left)
        };
        talkData.Add(20, t);
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