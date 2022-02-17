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

    bool istalk = true;
    bool Isque;
    bool keeptalk = false;
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
        StartTalkBtn.onClick.AddListener(() =>
        {
            StartCoroutine(ETalkEvent());
        });
        KeepTalkBtn.onClick.AddListener(() =>
        {
            keeptalk = true;
            Keepchoice.SetActive(false);
        });
    }

    private void Update()
    {
        //choiceId = (int)Etalk * 10 - 10;
    }
    void TalkSet()
    {
        switch (Etalk)
        {
            case TalkChoice.Kang:
                Talkstart = "PlayerName(이) 왔구나! 무슨 일 이야?";
                break;
            case TalkChoice.Yang:
                Talkstart = "오셨군요! 기다리고 있었어요.";
                break;
            case TalkChoice.Baek:
                //Talkstart = "";
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
            case 0:
                //switch (Etalk)
                //{
                //    case TalkChoice.Story:
                //        break;
                //    case TalkChoice.Kang:
                //        break;
                //    case TalkChoice.Yang:
                //        break;
                //    case TalkChoice.Baek:
                //        break;
                //    default:
                //        break;
                //}
                switch ((int)Etalk)
                {
                    case 1:
                        kang += 20;
                        itemtext = "귀여운 곰돌이다! 나한테 주는거야? 고마워~";
                        break;
                    case 2:
                        yang += 10;
                        itemtext = "저에게 주시는 건가요..? 감사해요";
                        break;
                    case 3:
                        break;
                }
                break;
            case 1:
                switch ((int)Etalk)
                {
                    case 1:
                        kang += 10;
                        itemtext = "선물? 고마워-! 잘 받을게!";
                        break;
                    case 2:
                        yang -= 20;
                        itemtext = "저.. 꽃가루 알르레기가 심해서…";
                        break;
                    case 3:
                        break;
                }
                break;
            case 2:
                switch ((int)Etalk)
                {
                    case 1:
                        kang += 10;
                        itemtext = "선물? 고마워-! 잘 받을게!";
                        break;
                    case 2:
                        yang += 10;
                        itemtext = "저에게 주시는 건가요..? 감사해요";
                        break;
                    case 3:
                        break;
                }
                break;
            case 3:
                switch ((int)Etalk)
                {
                    case 1:
                        itemtext = "너 이런 내용이 진심으로 가윤이한테 통할 거라고 생각했어…?";
                        break;
                    case 2:
                        itemtext = "가윤이 한테 보낸…? 이걸 왜 저한테…";
                        break;
                    case 3:
                        break;
                }
                break;
            case 4:
                switch ((int)Etalk)
                {
                    case 1:
                        kang += 10;
                        itemtext = "선물? 고마워-! 잘 받을게!";
                        break;
                    case 2:
                        yang += 20;
                        itemtext = "읽어본적 없는 책 이네요.. 절 위해서..? 고마워요 잘 읽을게요";
                        break;
                    case 3:
                        break;
                }
                break;
            case 5:
                switch ((int)Etalk)
                {
                    case 1:
                        kang += 10;
                        itemtext = "선물? 고마워-! 잘 받을게!";
                        break;
                    case 2:
                        yang += 10;
                        itemtext = "저에게 주시는 건가요..? 감사해요";
                        break;
                    case 3:
                        break;
                }
                break;
            case 6:
                switch ((int)Etalk)
                {
                    case 1:
                        kang += 10;
                        itemtext = "선물? 고마워-! 잘 받을게!";
                        break;
                    case 2:
                        yang += 10;
                        itemtext = "저에게 주시는 건가요..? 감사해요";
                        break;
                    case 3:
                        break;
                }
                break;
            case 7:
                switch ((int)Etalk)
                {
                    case 1:
                        kang += 10;
                        itemtext = "선물? 고마워-! 잘 받을게!";
                        break;
                    case 2:
                        yang += 10;
                        itemtext = "저에게 주시는 건가요..? 감사해요";
                        break;
                    case 3:
                        break;
                }
                break;
            case 8:
                switch ((int)Etalk)
                {
                    case 1:
                        kang -= 20;
                        itemtext = "내가 너한테 홍차 싫어한다고 말 안했던가?";
                        break;
                    case 2:
                        yang += 10;
                        itemtext = "저에게 주시는 건가요..? 감사해요";
                        break;
                    case 3:
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

        //Talk Progress
        var talkprogs = loader.LoadTalkData();

        talkprog = talkprogs;

        talkNum = talkprog.Talkprog[(int)Etalk - 1];

        //bool talkstart = false;

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
            //txtName.text = talk.talkDatas[prog].name.Replace("%PlayerName%", GameManager.Instance.PlayerName);
            string talk1 = talk.talkDatas[prog].talk;
            txtTalk.text = talk1;

            BackgroundManager.Instance.CharChange(talk.talkDatas[prog].Kang, talk.talkDatas[prog].Yang, talk.talkDatas[prog].Baek);
            print("Change");
            yield return StartCoroutine(ETextTyping(txtTalk, talk1));
            //choice
            choiceId = prog;
            if (choiceId != (int)Etalk * 10)
                choice = choices[choiceId++];
            for (int j = 0; j < choice.choiceDatas.Count; j++)
            {
                Choicetexts.Add(Choicebtn);
                TalkChoices.Add(choice.choiceDatas[j]);
                background.Add(choice.choiceDatas[j]);
                Likenum.Add(choice.choiceDatas[j].like);
            }
            Isque = true;
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

                TextMeshProUGUI choicetext = obj.transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>();
                choicetext.text = TalkChoices[randtext].choice;
                TalkChoices.RemoveAt(randtext);

                obj.onClick.AddListener(() =>
                {
                    ItemLoad.Instance.SetLikeValue(Likenum[randtext], (int)Etalk);
                    Likenum.RemoveAt(randtext);

                    talk1 = obj.GetComponent<BtnMgr>().BtnChoiceText;
                    BtnMgr cg = obj.GetComponent<BtnMgr>();
                    BackgroundManager.Instance.CharChange(cg.Kang, background[randtext1].Yang, background[randtext1].Baek);
                    background.RemoveAt(randtext);
                    StartCoroutine(ETextTyping(txtTalk, talk1));
                    DeleteChilds();

                    Isque = false;
                    Keepchoice.SetActive(true);
                });
            }
            //istalk = false;
            talkprog.Talkprog[(int)Etalk - 1] = prog;
            saver.SaveTalk(talkprog);

            //BackgroundManager.Instance.CharChange(talk.talkDatas[prog].Kang, talk.talkDatas[prog].Yang, talk.talkDatas[prog].Baek);

            if (prog + 1 == talk.talkDatas.Count) continue;
            print("Click before");
            yield return StartCoroutine(EWaitClick());
            print("Click After");
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

    private void OnDestroy()
    {
        Instance = null;
    }
}
