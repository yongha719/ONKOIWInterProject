using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

//                                      |
// 쓰는쪽 ( TalkManager ) ---> ITalkLoad | <--- JsonLoader 서비스 주는 애
//                                      |

//
// 쓰는쪽 ( TalkManager ) ---> JsonLoader
//
public enum TalkChoice
{
    Story, Kang, Yang, Baek
}

public class TalkManager : MonoBehaviour
{
    public static TalkManager Instance { get; private set; } = null;
    public ITalkLoad loader;
    public ITalkSave saver;
    [SerializeField] private TextMeshProUGUI txtName;
    [SerializeField] private TextMeshProUGUI txtTalk;
    [SerializeField] private RectTransform rtrnChoiceParent;
    [SerializeField] private Button Choicebtn;
    [SerializeField] private int talkId;
    [SerializeField] private int choiceId;
    [SerializeField] Button StartTalkBtn;
    [SerializeField] GameObject Keepchoice;
    [SerializeField] Button KeepTalkBtn;

    [SerializeField] GameObject MiniGame;
    [SerializeField] Button GoMiniGameBtn;

    bool IsGame = false;
    bool keeptalk = false;
    bool Minigame = false;
    string Talkstart;

    int talkNum = 0;
    int prog;

    public TalkChoice Etalk;
    public TalkProgress talkprog;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        loader = new JsonLoader();
        saver = new JsonLoader();

        if (SceneManager.GetActiveScene().name == "InGame")
            StartCoroutine(StoryEvent());
        if (SceneManager.GetActiveScene().name == "MiniStory")
            StartCoroutine(EndingEvent());
        StartTalkBtn.onClick.AddListener(() =>
        {
            StartCoroutine(ETalkEvent());
        });
        KeepTalkBtn.onClick.AddListener(() =>
        {
            keeptalk = true;
            Keepchoice.SetActive(false);
        });
        GoMiniGameBtn.onClick.AddListener(() =>
        {
            Minigame = true;
            switch (Etalk)
            {
                case TalkChoice.Kang:
                    SceneManager.LoadScene("Shooting");
                    break;
                case TalkChoice.Yang:
                    break;
                case TalkChoice.Baek:
                    break;
                default:
                    break;
            }
        });
    }

    private void Update()
    {

    }
    void TalkSet()
    {
        switch (Etalk)
        {
            case TalkChoice.Kang:
                Talkstart = "PlayerName(이) 왔구나! 무슨 일 이야?";
                BackgroundManager.Instance.AnimationChange(1, Etalk);
                break;
            case TalkChoice.Yang:
                Talkstart = "오셨군요! 기다리고 있었어요.";
                BackgroundManager.Instance.AnimationChange(1, Etalk);
                break;
            case TalkChoice.Baek:
                Talkstart = "왔어? 어서 돌아갈 방법을 생각해 보자";
                BackgroundManager.Instance.AnimationChange(1, Etalk);
                break;
            default:
                break;
        }
    }

    public IEnumerator StoryEvent()
    {
        var talks = loader.LoadTalk();

        TalkDatas talk = default;

        talk = talks[(int)TalkChoice.Story];
        for (int i = 0; i < talk.talkDatas.Count; i++)
        {
            BackgroundManager.Instance.BackGroundChange(talk.talkDatas[i].background);
            BackgroundManager.Instance.CharChange(talk.talkDatas[i].Kang, talk.talkDatas[i].Yang, talk.talkDatas[i].Baek);
            txtName.text = talk.talkDatas[i].name.Replace("%PlayerName%", GameManager.Instance.PlayerName);
            string talk1 = talk.talkDatas[i].talk.Replace("PlayerName", GameManager.Instance.PlayerName);
            txtTalk.text = talk1;

            yield return StartCoroutine(ETextTyping(txtTalk, talk1));

            if (i + 1 == talk.talkDatas.Count) continue;
            yield return StartCoroutine(EWaitInput());
        }

        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Love");
        yield return null;
    }

    public void EGiftEvent(int check)
    {
        float kang = ItemLoad.Instance.chaeAhlike;
        float yang = ItemLoad.Instance.seHwalike;
        float baek = ItemLoad.Instance.gaYoonlike;
        string itemtext = null;
        switch (check)
        {
            case 0://곰인형
                switch ((int)Etalk)
                {
                    case 1:
                        kang += 20;
                        itemtext = "귀여운 곰돌이다! 나한테 주는거야? 고마워~";
                        BackgroundManager.Instance.AnimationChange(11, Etalk);
                        break;
                    case 2:
                        yang += 10;
                        itemtext = "저에게 주시는 건가요..? 감사해요";
                        BackgroundManager.Instance.AnimationChange(7, Etalk);
                        break;
                    case 3:
                        baek += 10;
                        itemtext = "나한테 선물? 아무튼 잘 받을게 고마워";
                        BackgroundManager.Instance.AnimationChange(8, Etalk);
                        break;
                }
                break;
            case 1://꽃 한 송이
                switch ((int)Etalk)
                {
                    case 1:
                        kang += 10;
                        itemtext = "선물? 고마워-! 잘 받을게!";
                        BackgroundManager.Instance.AnimationChange(8, Etalk);
                        break;
                    case 2:
                        yang -= 20;
                        itemtext = "저.. 꽃가루 알르레기가 심해서…";
                        BackgroundManager.Instance.AnimationChange(4, Etalk);
                        break;
                    case 3:
                        baek += 10;
                        itemtext = "나한테 선물? 아무튼 잘 받을게 고마워";
                        BackgroundManager.Instance.AnimationChange(8, Etalk);
                        break;
                }
                break;
            case 2://롤리팝
                switch ((int)Etalk)
                {
                    case 1:
                        kang += 10;
                        itemtext = "선물? 고마워-! 잘 받을게!";
                        BackgroundManager.Instance.AnimationChange(8, Etalk);
                        break;
                    case 2:
                        yang += 10;
                        itemtext = "저에게 주시는 건가요..? 감사해요";
                        BackgroundManager.Instance.AnimationChange(7, Etalk);
                        break;
                    case 3:
                        baek += 10;
                        itemtext = "나한테 선물? 아무튼 잘 받을게 고마워";
                        BackgroundManager.Instance.AnimationChange(8, Etalk);
                        break;
                }
                break;
            case 3://버려진 러브레터
                switch ((int)Etalk)
                {
                    case 1:
                        itemtext = "너 이런 내용이 진심으로 가윤이한테 통할 거라고 생각했어…?";
                        BackgroundManager.Instance.AnimationChange(3, Etalk);
                        break;
                    case 2:
                        itemtext = "가윤이 한테 보낸…? 이걸 왜 저한테…";
                        BackgroundManager.Instance.AnimationChange(3, Etalk);
                        break;
                    case 3:
                        baek -= 20;
                        itemtext = "너 이 상황에 제정신이야?";
                        BackgroundManager.Instance.AnimationChange(4, Etalk);
                        break;
                }
                break;
            case 4://소설책
                switch ((int)Etalk)
                {
                    case 1:
                        kang += 10;
                        itemtext = "선물? 고마워-! 잘 받을게!";
                        BackgroundManager.Instance.AnimationChange(8, Etalk);
                        break;
                    case 2:
                        yang += 20;
                        itemtext = "읽어본적 없는 책 이네요.. 절 위해서..? 고마워요 잘 읽을게요";
                        BackgroundManager.Instance.AnimationChange(6, Etalk);
                        break;
                    case 3:
                        baek += 10;
                        itemtext = "나한테 선물? 아무튼 잘 받을게 고마워";
                        BackgroundManager.Instance.AnimationChange(8, Etalk);
                        break;
                }
                break;
            case 5://초콜릿
                switch ((int)Etalk)
                {
                    case 1:
                        kang += 10;
                        itemtext = "선물? 고마워-! 잘 받을게!";
                        BackgroundManager.Instance.AnimationChange(8, Etalk);
                        break;
                    case 2:
                        yang += 10;
                        itemtext = "저에게 주시는 건가요..? 감사해요";
                        BackgroundManager.Instance.AnimationChange(7, Etalk);
                        break;
                    case 3:
                        baek += 20;
                        itemtext = "초콜릿? 뭐.. 단거 좋아한다고 어디 말하고 다닌 적 없는데\n어떻게 알았어? …아무튼 고마워";
                        BackgroundManager.Instance.AnimationChange(6, Etalk);
                        break;
                }
                break;
            case 6://커피우유
                switch ((int)Etalk)
                {
                    case 1:
                        kang += 10;
                        itemtext = "선물? 고마워-! 잘 받을게!";
                        BackgroundManager.Instance.AnimationChange(8, Etalk);
                        break;
                    case 2:
                        yang += 10;
                        itemtext = "저에게 주시는 건가요..? 감사해요";
                        BackgroundManager.Instance.AnimationChange(7, Etalk);
                        break;
                    case 3:
                        baek += 10;
                        itemtext = "나한테 선물? 아무튼 잘 받을게 고마워";
                        BackgroundManager.Instance.AnimationChange(8, Etalk);
                        break;
                }
                break;
            case 7://필기도구
                switch ((int)Etalk)
                {
                    case 1:
                        kang += 10;
                        itemtext = "선물? 고마워-! 잘 받을게!";
                        BackgroundManager.Instance.AnimationChange(8, Etalk);
                        break;
                    case 2:
                        yang += 10;
                        itemtext = "저에게 주시는 건가요..? 감사해요";
                        BackgroundManager.Instance.AnimationChange(7, Etalk);
                        break;
                    case 3:
                        baek += 10;
                        itemtext = "나한테 선물? 아무튼 잘 받을게 고마워";
                        BackgroundManager.Instance.AnimationChange(8, Etalk);
                        break;
                }
                break;
            case 8://홍차
                switch ((int)Etalk)
                {
                    case 1:
                        kang -= 20;
                        itemtext = "내가 너한테 홍차 싫어한다고 말 안했던가?";
                        BackgroundManager.Instance.AnimationChange(3, Etalk);
                        break;
                    case 2:
                        yang += 10;
                        itemtext = "저에게 주시는 건가요..? 감사해요";
                        BackgroundManager.Instance.AnimationChange(7, Etalk);
                        break;
                    case 3:
                        baek += 10;
                        itemtext = "나한테 선물? 아무튼 잘 받을게 고마워";
                        BackgroundManager.Instance.AnimationChange(8, Etalk);
                        break;
                }
                break;
            default:
                break;
        }
        ItemLoad.Instance.SetLikeValue(kang, yang, baek);
        StartCoroutine(ETextTyping(txtTalk, itemtext));
    }

    public IEnumerator ETalkEvent()
    {
        List<ChoiceData> TalkChoices = new List<ChoiceData>();
        List<ChoiceData> background = new List<ChoiceData>();
        List<int> Likenum = new List<int>();

        List<Button> Choicetexts = new List<Button>();

        var talks = loader.LoadTalk();
        var choices = loader.LoadChoice();

        TalkDatas talk = talks[(int)Etalk];
        ChoiceDatas choice = default;

        var talkprogs = loader.LoadTalkData();

        talkprog = talkprogs;

        talkNum = talkprog.Talkprog[(int)Etalk - 1];

        for (prog = talkNum; prog < talk.talkDatas.Count; prog++)
        {
            if (prog == 0)
            {
                txtTalk.text = null;
                TalkSet();
                yield return StartCoroutine(ETextTyping(txtTalk, Talkstart));

                yield return StartCoroutine(EWaitInput());
                //talkstart = true;
            }
            SetGoMini(prog);
            BackgroundManager.Instance.CharChange(talk.talkDatas[prog].Kang, talk.talkDatas[prog].Yang, talk.talkDatas[prog].Baek);
            string talk1 = talk.talkDatas[prog].talk;
            txtTalk.text = talk1;
            yield return StartCoroutine(ETextTyping(txtTalk, talk1));

            choiceId = prog + ((int)Etalk - 1) * 10;
            if (choiceId < (int)Etalk * 10)
            {
                choice = choices[choiceId++];

                for (int j = 0; j < choice.choiceDatas.Count; j++)
                {
                    Choicetexts.Add(Choicebtn);
                    TalkChoices.Add(choice.choiceDatas[j]);
                    background.Add(choice.choiceDatas[j]);
                    Likenum.Add(choice.choiceDatas[j].like);
                }
                for (int j = 0; j < choice.choiceDatas.Count; j++)
                {
                    int rand = Random.Range(0, Choicetexts.Count);
                    var obj = Instantiate(Choicetexts[rand], rtrnChoiceParent);
                    Choicetexts.RemoveAt(rand);

                    BtnMgr btnmgr = obj.GetComponent<BtnMgr>();
                    int randtext = Random.Range(0, TalkChoices.Count);
                    int randtext1 = Random.Range(0, background.Count);
                    btnmgr.BtnChoiceText = TalkChoices[randtext].reply;
                    btnmgr.Kang = TalkChoices[randtext].Kang;
                    btnmgr.Yang = TalkChoices[randtext].Yang;
                    btnmgr.Baek = TalkChoices[randtext].Baek;
                    btnmgr.like = TalkChoices[randtext].like;
                    TextMeshProUGUI choicetext = obj.transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>();
                    choicetext.text = TalkChoices[randtext].choice;
                    TalkChoices.RemoveAt(randtext);

                    obj.onClick.AddListener(() =>
                    {
                        BtnMgr cg = obj.GetComponent<BtnMgr>();
                        ItemLoad.Instance.SetLikeValue(cg.like, (int)Etalk);
                        Likenum.RemoveAt(randtext);

                        talk1 = obj.GetComponent<BtnMgr>().BtnChoiceText;
                        BackgroundManager.Instance.CharChange(cg.Kang, background[randtext1].Yang, background[randtext1].Baek);
                        background.RemoveAt(randtext);
                        StartCoroutine(ETextTyping(txtTalk, talk1));
                        DeleteChilds();

                        Keepchoice.SetActive(true);
                    });
                }
                yield return StartCoroutine(EWaitClick());
            }

            talkprog.Talkprog[(int)Etalk - 1] = prog + 1;
            saver.SaveTalk(talkprog);

            //if (choiceId == (int)Etalk * 10) MiniGame.SetActive(true);
            if (IsGame) break;
            //StopCoroutine(ETalkEvent());
            if (prog + 1 == talk.talkDatas.Count) continue;
            if (choiceId >= (int)Etalk * 10) yield return StartCoroutine(EWaitInput());
        }
        yield return null;

    }

    public IEnumerator EndingEvent()
    {
        var kangendings = loader.LoadKangEnding();
        var yangendings = loader.LoadYangEnding();
        var baekendings = loader.LoadBaekEnding();
        KangEndings kangending = default;
        YangEndings yangending = default;
        BaekEndings baekending = default;

        switch (Etalk)
        {
            case TalkChoice.Kang:
                if (!GameManager.Instance.Mini1Clear)
                    kangending = kangendings[0];
                else if (GameManager.Instance.Mini1Clear && ItemLoad.Instance.ChaeAhlike < 80)
                    kangending = kangendings[1];
                else if (GameManager.Instance.Mini1Clear && ItemLoad.Instance.ChaeAhlike >= 80)
                    kangending = kangendings[2];
                for (int i = 0; i < kangending.kangendings.Count; i++)
                {
                    BackgroundManager.Instance.BackGroundChange(kangending.kangendings[i].background);
                    txtName.text = kangending.kangendings[i].name.Replace("%PlayerName%", GameManager.Instance.PlayerName);
                    txtTalk.text = kangending.kangendings[i].talk;
                    yield return StartCoroutine(ETextTyping(txtTalk , txtTalk.text));

                    yield return StartCoroutine(EWaitInput());
                }
                break;
            case TalkChoice.Yang:
                if (!GameManager.Instance.Mini2Clear)
                    yangending = yangendings[0];
                else if (GameManager.Instance.Mini2Clear && ItemLoad.Instance.SeHwalike < 80)
                    yangending = yangendings[1];
                else if (GameManager.Instance.Mini2Clear && ItemLoad.Instance.SeHwalike >= 80)
                    yangending = yangendings[2];
                for (int i = 0; i < yangending.yangendings.Count; i++)
                {
                    BackgroundManager.Instance.BackGroundChange(yangending.yangendings[i].background);
                    txtName.text = yangending.yangendings[i].name.Replace("%PlayerName%", GameManager.Instance.PlayerName); ;
                    txtTalk.text = yangending.yangendings[i].talk;

                    yield return StartCoroutine(ETextTyping(txtTalk, txtTalk.text));

                    yield return StartCoroutine(EWaitInput());
                }
                break;
            case TalkChoice.Baek:
                if (!GameManager.Instance.Mini3Clear)
                    baekending = baekendings[0];
                else if (GameManager.Instance.Mini3Clear && ItemLoad.Instance.GaYoonlike < 80)
                    baekending = baekendings[1];
                else if (GameManager.Instance.Mini3Clear && ItemLoad.Instance.GaYoonlike >= 80)
                    baekending = baekendings[2];
                for (int i = 0; i < baekending.baekendings.Count; i++)
                {
                    BackgroundManager.Instance.BackGroundChange(baekending.baekendings[i].background);
                    txtName.text = baekending.baekendings[i].name.Replace("%PlayerName%", GameManager.Instance.PlayerName); ;
                    txtTalk.text = baekending.baekendings[i].talk;

                    yield return StartCoroutine(ETextTyping(txtTalk, txtTalk.text));

                    yield return StartCoroutine(EWaitInput());
                }
                break;
            default:
                break;
        }
        
        yield return null;
    }
    public void DeleteChilds()
    {
        var child = rtrnChoiceParent.GetComponentsInChildren<RectTransform>();

        foreach (var iter in child)
        {
            if (iter != rtrnChoiceParent.transform)
            {
                Destroy(iter.gameObject);
            }
        }
    }

    IEnumerator EWaitInput()
    {
        var wait = new WaitForSeconds(0.001f);
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                yield return new WaitForSeconds(0.1f);
                yield break;
            }
            yield return wait;
        }
    }
    IEnumerator EWaitClick()
    {
        var wait = new WaitForSeconds(0.001f);
        while (true)
        {
            if (keeptalk)
            {
                yield return new WaitForSeconds(0.1f);
                keeptalk = false;

                yield break;
            }
            else if (Minigame)
            {
                yield return new WaitForSeconds(0.1f);
                keeptalk = false;

                yield break;
            }
            yield return wait;
        }
    }

    IEnumerator ETextTyping(TextMeshProUGUI text, string newString)
    {
        var wait = new WaitForSeconds(0.05f);
        newString = newString.Replace("PlayerName", GameManager.Instance.PlayerName);
        for (int i = 0; i <= newString.Length; i++)
        {
            text.text = newString.Substring(0, i);
            if (Input.GetKey(KeyCode.X))
                wait = new WaitForSeconds(0);
            yield return wait;
        }

        yield return null;
    }
    void SetGoMini(int prog)
    {
        switch (Etalk)
        {
            case TalkChoice.Kang:
                if (prog == 22)
                {
                    MiniGame.SetActive(true);
                    IsGame = true;
                }
                break;
            case TalkChoice.Yang:
                if (prog == 26)
                {
                    MiniGame.SetActive(true);
                    IsGame = true;
                }
                break;
            case TalkChoice.Baek:
                if (prog == 35)
                {
                    MiniGame.SetActive(true);
                    IsGame = true;
                }
                break;
            default:
                break;
        }
    }
    private void OnDestroy()
    {
        Instance = null;
    }
}
