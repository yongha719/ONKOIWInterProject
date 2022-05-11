using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using Random = UnityEngine.Random;

public enum TalkChoice
{
    Story, Kang, Yang, Baek
}

public class TalkManager : MonoBehaviour
{
    public static TalkManager Instance { get; private set; } = null;
    private void Awake() => Instance = this;

    const int LAST_CHIOCE_TALK_NUM = 9;
    const int LAST_KANG_TALK_NUM = 22;
    const int LAST_YANG_TALK_NUM = 26;
    const int LAST_BAEK_TALK_NUM = 35;

    public ITalkLoad loader;
    public ITalkSave saver;

    [SerializeField] private TextMeshProUGUI txtName;
    [SerializeField] private TextMeshProUGUI txtTalk;
    [SerializeField] private RectTransform rtrnChoiceParent;
    [SerializeField] private Button ChoiceBtn;
    [SerializeField] private int talkId;
    [SerializeField] private int choiceId;

    [SerializeField] GameObject Keepchoice;
    [SerializeField] GameObject GiftWarning;
    [SerializeField] Button StartTalkBtn;
    [SerializeField] Button KeepTalkBtn;
    [SerializeField] Button BackTalkBtn;

    [SerializeField] GameObject GoMiniGame;
    [SerializeField] Button GoMiniGameBtn;

    bool IsGame = false;
    bool keeptalk = false;
    bool IsMinigamePlaying = false;
    string Talkstart;

    int talkNum = 0;
    int talkProg;

    public TalkChoice Etalk;
    public TalkProgress talkprog;

    GameManager Gm;
    ItemLoad ItemLoadInst;

    private void Start()
    {
        Gm = GameManager.Instance;
        ItemLoadInst = ItemLoad.Instance;

        loader = new JsonLoader();
        saver = new JsonLoader();

        talkprog = loader.LoadTalkData();

        if (SceneManager.GetActiveScene().name.Equals("InGame"))
            StartCoroutine(StoryEvent());
        if (SceneManager.GetActiveScene().name.Equals("MiniStory"))
            StartCoroutine(EndingEvent());

        ButtonSetting();
    }

    void ButtonSetting()
    {
        StartTalkBtn.onClick.AddListener(() =>
        {
            StartCoroutine(ETalkEvent());
            StartCoroutine(IKeepTalk());
        });

        KeepTalkBtn.onClick.AddListener(() =>
        {
            StartCoroutine(IKeepTalk());
            keeptalk = true;
            Keepchoice.SetActive(false);
        });

        BackTalkBtn.onClick.AddListener(() =>
        {
            talkprog.Talkprog[(int)Etalk - 1] = talkProg + 1;
            saver.SaveTalk(talkprog);
        });

        GoMiniGameBtn.onClick.AddListener(() =>
        {
            IsMinigamePlaying = true;
            switch (Etalk)
            {
                case TalkChoice.Kang:
                    SceneManager.LoadScene("Shooting");
                    break;
                case TalkChoice.Yang:
                    SceneManager.LoadScene("MiniGame");
                    break;
                case TalkChoice.Baek:
                    SceneManager.LoadScene("MiniGame3");
                    break;
                default:
                    Debug.Assert(false);
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
                BackgroundManager.Instance.SetCharAni(1);
                break;
            case TalkChoice.Yang:
                Talkstart = "오셨군요! 기다리고 있었어요.";
                BackgroundManager.Instance.SetCharAni(1);
                break;
            case TalkChoice.Baek:
                Talkstart = "왔어? 어서 돌아갈 방법을 생각해 보자";
                BackgroundManager.Instance.SetCharAni(1);
                break;
            default:
                Debug.Assert(false);
                break;
        }
    }

    public IEnumerator StoryEvent()
    {
        var talks = loader.LoadTalk();

        TalkDatas talk = talks[(int)TalkChoice.Story];

        for (int i = 0; i < talk.talkDatas.Count; i++)
        {
            BackgroundManager.Instance.CharChange(talk.talkDatas[i].Kang, talk.talkDatas[i].Yang, talk.talkDatas[i].Baek);
            BackgroundManager.Instance.BackGroundChange(talk.talkDatas[i].background);

            txtName.text = talk.talkDatas[i].name.Replace("%PlayerName%", Gm.PlayerName);
            txtTalk.text = talk.talkDatas[i].talk;

            yield return StartCoroutine(ETextTyping(txtTalk, txtTalk.text));

            if (i + 1 == talk.talkDatas.Count) continue;
            yield return StartCoroutine(EWaitInput());
        }

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Love");
        yield return null;
    }

    public void EGiftEvent(int check)
    {
        float kang = ItemLoadInst.chaeAhlike;
        float yang = ItemLoadInst.seHwalike;
        float baek = ItemLoadInst.gaYoonlike;
        string itemtext = null;
        switch (check)
        {
            case 0://곰인형
                switch ((int)Etalk)
                {
                    case 1:
                        kang += 20;
                        itemtext = "귀여운 곰돌이다! 나한테 주는거야? 고마워~";
                        BackgroundManager.Instance.SetCharAni(11);
                        break;
                    case 2:
                        yang += 10;
                        itemtext = "저에게 주시는 건가요..? 감사해요";
                        BackgroundManager.Instance.SetCharAni(7);
                        break;
                    case 3:
                        baek += 10;
                        itemtext = "나한테 선물? 아무튼 잘 받을게 고마워";
                        BackgroundManager.Instance.SetCharAni(8);
                        break;
                    default: Debug.Assert(false); break;
                }
                break;
            case 1://꽃 한 송이
                switch ((int)Etalk)
                {
                    case 1:
                        kang += 10;
                        itemtext = "선물? 고마워-! 잘 받을게!";
                        BackgroundManager.Instance.SetCharAni(8);
                        break;
                    case 2:
                        yang -= 20;
                        itemtext = "저.. 꽃가루 알르레기가 심해서…";
                        BackgroundManager.Instance.SetCharAni(4);
                        break;
                    case 3:
                        baek += 10;
                        itemtext = "나한테 선물? 아무튼 잘 받을게 고마워";
                        BackgroundManager.Instance.SetCharAni(8);
                        break;
                    default: Debug.Assert(false); break;
                }
                break;
            case 2://롤리팝
                switch ((int)Etalk)
                {
                    case 1:
                        kang += 10;
                        itemtext = "선물? 고마워-! 잘 받을게!";
                        BackgroundManager.Instance.SetCharAni(8);
                        break;
                    case 2:
                        yang += 10;
                        itemtext = "저에게 주시는 건가요..? 감사해요";
                        BackgroundManager.Instance.SetCharAni(7);
                        break;
                    case 3:
                        baek += 10;
                        itemtext = "나한테 선물? 아무튼 잘 받을게 고마워";
                        BackgroundManager.Instance.SetCharAni(8);
                        break;
                    default: Debug.Assert(false); break;
                }
                break;
            case 3://버려진 러브레터
                switch ((int)Etalk)
                {
                    case 1:
                        itemtext = "너 이런 내용이 진심으로 가윤이한테 통할 거라고 생각했어…?";
                        BackgroundManager.Instance.SetCharAni(3);
                        break;
                    case 2:
                        itemtext = "가윤이 한테 보낸…? 이걸 왜 저한테…";
                        BackgroundManager.Instance.SetCharAni(3);
                        break;
                    case 3:
                        baek -= 20;
                        itemtext = "너 이 상황에 제정신이야?";
                        BackgroundManager.Instance.SetCharAni(4);
                        break;
                    default: Debug.Assert(false); break;
                }
                break;
            case 4://소설책
                switch ((int)Etalk)
                {
                    case 1:
                        kang += 10;
                        itemtext = "선물? 고마워-! 잘 받을게!";
                        BackgroundManager.Instance.SetCharAni(8);
                        break;
                    case 2:
                        yang += 20;
                        itemtext = "읽어본적 없는 책 이네요.. 절 위해서..? 고마워요 잘 읽을게요";
                        BackgroundManager.Instance.SetCharAni(6);
                        break;
                    case 3:
                        baek += 10;
                        itemtext = "나한테 선물? 아무튼 잘 받을게 고마워";
                        BackgroundManager.Instance.SetCharAni(8);
                        break;
                    default: Debug.Assert(false); break;
                }
                break;
            case 5://초콜릿
                switch ((int)Etalk)
                {
                    case 1:
                        kang += 10;
                        itemtext = "선물? 고마워-! 잘 받을게!";
                        BackgroundManager.Instance.SetCharAni(8);
                        break;
                    case 2:
                        yang += 10;
                        itemtext = "저에게 주시는 건가요..? 감사해요";
                        BackgroundManager.Instance.SetCharAni(7);
                        break;
                    case 3:
                        baek += 20;
                        itemtext = "초콜릿? 뭐.. 단거 좋아한다고 어디 말하고 다닌 적 없는데\n어떻게 알았어? …아무튼 고마워";
                        BackgroundManager.Instance.SetCharAni(6);
                        break;
                    default: Debug.Assert(false); break;
                }
                break;
            case 6://커피우유
                switch ((int)Etalk)
                {
                    case 1:
                        kang += 10;
                        itemtext = "선물? 고마워-! 잘 받을게!";
                        BackgroundManager.Instance.SetCharAni(8);
                        break;
                    case 2:
                        yang += 10;
                        itemtext = "저에게 주시는 건가요..? 감사해요";
                        BackgroundManager.Instance.SetCharAni(7);
                        break;
                    case 3:
                        baek += 10;
                        itemtext = "나한테 선물? 아무튼 잘 받을게 고마워";
                        BackgroundManager.Instance.SetCharAni(8);
                        break;
                    default: Debug.Assert(false); break;
                }
                break;
            case 7://필기도구
                switch ((int)Etalk)
                {
                    case 1:
                        kang += 10;
                        itemtext = "선물? 고마워-! 잘 받을게!";
                        BackgroundManager.Instance.SetCharAni(8);
                        break;
                    case 2:
                        yang += 10;
                        itemtext = "저에게 주시는 건가요..? 감사해요";
                        BackgroundManager.Instance.SetCharAni(7);
                        break;
                    case 3:
                        baek += 10;
                        itemtext = "나한테 선물? 아무튼 잘 받을게 고마워";
                        BackgroundManager.Instance.SetCharAni(8);
                        break;
                    default: Debug.Assert(false); break;
                }
                break;
            case 8://홍차
                switch ((int)Etalk)
                {
                    case 1:
                        kang -= 20;
                        itemtext = "내가 너한테 홍차 싫어한다고 말 안했던가?";
                        BackgroundManager.Instance.SetCharAni(3);
                        break;
                    case 2:
                        yang += 10;
                        itemtext = "저에게 주시는 건가요..? 감사해요";
                        BackgroundManager.Instance.SetCharAni(7);
                        break;
                    case 3:
                        baek += 10;
                        itemtext = "나한테 선물? 아무튼 잘 받을게 고마워";
                        BackgroundManager.Instance.SetCharAni(8);
                        break;
                    default: Debug.Assert(false); break;
                }
                break;
            default:
                Debug.Assert(false);
                break;
        }
        ItemLoadInst.SetLikeValue(kang, yang, baek);
        StartCoroutine(ETextTyping(txtTalk, itemtext));
    }

    public IEnumerator ETalkEvent()
    {
        var TalkChoices = new List<ChoiceData>();
        var background = new List<ChoiceData>();
        List<int> Likenums = new List<int>();

        List<Button> Choicetexts = new List<Button>();

        var talks = loader.LoadTalk();
        var choices = loader.LoadChoice();

        TalkDatas talk = talks[(int)Etalk];
        ChoiceDatas choice = default;

        talkNum = talkprog.Talkprog[(int)Etalk - 1];

        for (talkProg = talkNum; talkProg < talk.talkDatas.Count; talkProg++)
        {
            if (talkProg == 0)
            {
                txtTalk.text = null;
                TalkSet();
                yield return StartCoroutine(ETextTyping(txtTalk, Talkstart));

                yield return StartCoroutine(EWaitInput());
                //talkstart = true;
            }

            SetGoMini(talkProg);
            BackgroundManager.Instance.CharChange(talk.talkDatas[talkProg].Kang, talk.talkDatas[talkProg].Yang, talk.talkDatas[talkProg].Baek);
            string talk1 = talk.talkDatas[talkProg].talk;
            txtTalk.text = talk1;
            yield return StartCoroutine(ETextTyping(txtTalk, talk1));

            talkprog.Talkprog[(int)Etalk - 1] = talkProg + 1;
            saver.SaveTalk(talkprog);

            choiceId = talkProg + ((int)Etalk - 1) * 10;
            if (choiceId < (int)Etalk * 10)
            {
                choice = choices[choiceId++];

                for (int i = 0; i < choice.choiceDatas.Count; i++)
                {
                    Choicetexts.Add(ChoiceBtn);
                    TalkChoices.Add(choice.choiceDatas[i]);
                    Likenums.Add(choice.choiceDatas[i].like);
                    background.Add(choice.choiceDatas[i]);
                }

                for (int i = 0; i < choice.choiceDatas.Count; i++)
                {
                    int rand = Random.Range(0, Choicetexts.Count);

                    var choicebtn = Instantiate(Choicetexts[rand], rtrnChoiceParent);
                    ChioceBtnInfo CBtninfo = choicebtn.GetComponent<ChioceBtnInfo>();
                    Choicetexts.RemoveAt(rand);

                    int randtext = Random.Range(0, TalkChoices.Count);
                    SetBtn(TalkChoices, CBtninfo, randtext);

                    TextMeshProUGUI choicetext = choicebtn.transform.Find("choiceBtn").GetComponent<TextMeshProUGUI>();
                    choicetext.text = TalkChoices[randtext].choice;
                    TalkChoices.RemoveAt(randtext);

                    choicebtn.onClick.AddListener(() =>
                    {
                        ChioceBtnInfo info = choicebtn.GetComponent<ChioceBtnInfo>();
                        ItemLoadInst.SetLikeValue(info.chioce_like, Etalk);
                        Likenums.RemoveAt(randtext);

                        string choice = choicebtn.GetComponent<ChioceBtnInfo>().BtnChoiceText;
                        BackgroundManager.Instance.CharChange(info.chioce_Kang, info.chioce_Yang, info.chioce_Baek);
                        background.RemoveAt(randtext);
                        StartCoroutine(ETextTyping(txtTalk, choice));
                        DeleteChilds();

                        Keepchoice.SetActive(true);
                    });
                }
                yield return StartCoroutine(EWaitClick());
            }

            if (IsGame) break;

            if (talkProg + 1 == talk.talkDatas.Count) continue;
            if (choiceId >= (int)Etalk * 10) yield return StartCoroutine(EWaitInput());
        }
        yield return null;

    }
    void SetBtn(List<ChoiceData> TalkChoices, ChioceBtnInfo btnmgr, int randtext)
    {
        btnmgr.BtnChoiceText = TalkChoices[randtext].reply;

        btnmgr.chioce_Kang = TalkChoices[randtext].Kang;
        btnmgr.chioce_Yang = TalkChoices[randtext].Yang;
        btnmgr.chioce_Baek = TalkChoices[randtext].Baek;
        btnmgr.chioce_like = TalkChoices[randtext].like;
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
                if (!Gm.Mini1Clear)
                {
                    kangending = kangendings[0];
                }
                else if (Gm.Mini1Clear && Gm.kanglike < 80)
                {
                    kangending = kangendings[1];
                    Gm.ChaeahNormalBool = true;
                }
                else if (Gm.Mini1Clear && Gm.kanglike >= 80)
                {
                    kangending = kangendings[2];
                    Gm.ChaeahHappyBool = true;
                }

                for (int i = 0; i < kangending.kangendings.Count; i++)
                {
                    BackgroundManager.Instance.BackGroundChange(kangending.kangendings[i].background);
                    txtName.text = kangending.kangendings[i].name.Replace("%PlayerName%", Gm.PlayerName);
                    txtTalk.text = kangending.kangendings[i].talk;
                    yield return StartCoroutine(ETextTyping(txtTalk, txtTalk.text));

                    yield return StartCoroutine(EWaitInput());
                }
                break;
            case TalkChoice.Yang:
                if (!Gm.Mini2Clear)
                    yangending = yangendings[0];
                else if (Gm.Mini2Clear && Gm.yanglike < 80)
                {
                    Gm.SehwaNormalBool = true;
                    yangending = yangendings[1];
                }
                else if (Gm.Mini2Clear && Gm.yanglike >= 80)
                {
                    Gm.SehwaHappyBool = true;
                    yangending = yangendings[2];
                }

                for (int i = 0; i < yangending.yangendings.Count; i++)
                {
                    BackgroundManager.Instance.BackGroundChange(yangending.yangendings[i].background);
                    txtName.text = yangending.yangendings[i].name.Replace("%PlayerName%", Gm.PlayerName); ;
                    txtTalk.text = yangending.yangendings[i].talk;

                    yield return StartCoroutine(ETextTyping(txtTalk, txtTalk.text));

                    yield return StartCoroutine(EWaitInput());
                }
                break;
            case TalkChoice.Baek:
                if (!Gm.Mini3Clear)
                    baekending = baekendings[0];
                else if (Gm.Mini3Clear && Gm.beaklike < 80)
                {
                    Gm.GayoonNormalBool = true;
                    baekending = baekendings[1];
                }
                else if (Gm.Mini3Clear && Gm.beaklike >= 80)
                {
                    Gm.GaYoonHappyBool = true;
                    baekending = baekendings[2];
                }

                for (int i = 0; i < baekending.baekendings.Count; i++)
                {
                    BackgroundManager.Instance.BackGroundChange(baekending.baekendings[i].background);
                    txtName.text = baekending.baekendings[i].name.Replace("%PlayerName%", Gm.PlayerName);
                    txtTalk.text = baekending.baekendings[i].talk;

                    yield return StartCoroutine(ETextTyping(txtTalk, txtTalk.text));

                    yield return StartCoroutine(EWaitInput());
                }
                break;
            default:
                break;
        }
        Gm.AlbumSave();

        yield return null;
    }

    public IEnumerator EBeginMiniGame()
    {

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
            else if (IsMinigamePlaying)
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
        newString = newString.Replace("PlayerName", Gm.PlayerName);
        for (int i = 0; i <= newString.Length; i++)
        {
            text.text = newString.Substring(0, i);//StringBuilder
            if (Input.GetKey(KeyCode.X))
                wait = new WaitForSeconds(0);
            yield return wait;
        }

        saver.SaveTalk(talkprog);
        yield return null;
    }

    void SetGoMini(int prog)
    {
        switch (Etalk)
        {
            case TalkChoice.Kang:
                if (prog == LAST_KANG_TALK_NUM && ItemLoadInst.chaeAhItemCheck == 0)
                {
                    IsGame = true;
                    GoMiniGame.SetActive(true);
                }
                break;
            case TalkChoice.Yang:
                if (prog == LAST_YANG_TALK_NUM && ItemLoadInst.seHwaItemCheck == 0)
                {
                    IsGame = true;
                    GoMiniGame.SetActive(true);
                }
                break;
            case TalkChoice.Baek:
                if (prog == LAST_BAEK_TALK_NUM && ItemLoadInst.gaYoonItemCheck == 0)
                {
                    IsGame = true;
                    GoMiniGame.SetActive(true);
                }
                break;
            default:
                Debug.Assert(false);
                break;
        }
    }

    IEnumerator IKeepTalk()
    {
        if (talkProg == LAST_CHIOCE_TALK_NUM)
        {
            switch (Etalk)
            {
                case TalkChoice.Kang:
                    if (ItemLoadInst.chaeAhItemCheck != 0)
                    {
                        GiftWarning.SetActive(true);
                        yield return new WaitForSeconds(1f);
                        GiftWarning.SetActive(false);
                    }
                    break;
                case TalkChoice.Yang:
                    if (ItemLoadInst.seHwaItemCheck != 0)
                    {
                        GiftWarning.SetActive(true);
                        yield return new WaitForSeconds(1f);
                        GiftWarning.SetActive(false);
                    }
                    break;
                case TalkChoice.Baek:
                    if (ItemLoadInst.gaYoonItemCheck != 0)
                    {
                        GiftWarning.SetActive(true);
                        yield return new WaitForSeconds(1f);
                        GiftWarning.SetActive(false);
                    }
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }
        }
        else yield break;
    }
}
