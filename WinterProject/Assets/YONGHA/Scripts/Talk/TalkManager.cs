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

    public List<ChoiceDatas> choiceDatas;

    [SerializeField] private TextMeshProUGUI txtName;
    [SerializeField] private Text txtTalk;
    [SerializeField] private RectTransform rtrnChoiceParent;
    [SerializeField] private Button Choicebtn;
    [SerializeField] private int talkId;
    [SerializeField] private int choiceId;

    bool istalk = true;
    bool Isque;

    
    int KtalkNum = 0;
    int prog;

    public TalkChoice Etalk;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        loader = new JsonLoader();
        if (SceneManager.GetActiveScene().name != "InGame")
            StartCoroutine(ETalkEvent());
        //StartCoroutine(StoryEvent());
    }

    private void Update()
    {
        //choiceId = (int)Etalk * 10 - 10;
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
        SceneManager.LoadScene("Love(clone)");
        yield return null;
    }
    public IEnumerator ETalkEvent()
    {
        List<Button> Choicetexts = new List<Button>();

        List<ChoiceData> TalkChoices = new List<ChoiceData>();
        List<int> Likenum = new List<int>();

        var talks = loader.LoadTalk();
        var choices = loader.LoadChoice();

        TalkDatas talk = talks[(int)Etalk];
        ChoiceDatas choice = default;

        bool talkstart = false;

        for (prog = KtalkNum; prog < talk.talkDatas.Count; prog++)
        {
            if (!talkstart)
            {
                string newstring = txtTalk.text;
                txtTalk.text = null;
                yield return StartCoroutine(ETextTyping(txtTalk, newstring));

                yield return StartCoroutine(EWaitInput());
                talkstart = true;
            }
            //BackgroundManager.Instance.CharChange(talk.talkDatas[prog].Kang, talk.talkDatas[prog].Yang, talk.talkDatas[prog].Baek);
            txtName.text = talk.talkDatas[prog].name.Replace("%PlayerName%", GameManager.Instance.PlayerName);
            string talk1 = talk.talkDatas[prog].talk;
            txtTalk.text = talk1;


            if (istalk)
            {
                choice = choices[choiceId++];
                for (int j = 0; j < choice.choiceDatas.Count; j++)
                {
                    Choicetexts.Add(Choicebtn);
                    TalkChoices.Add(choice.choiceDatas[j]);
                    Likenum.Add(choice.choiceDatas[j].like);
                }
                Isque = true;
                for (int j = 0; j < choice.choiceDatas.Count; j++)
                {
                    int rand = Random.Range(0, Choicetexts.Count);
                    var obj = Instantiate(Choicetexts[rand], rtrnChoiceParent);
                    Choicetexts.RemoveAt(rand);

                    int randtext = Random.Range(0, TalkChoices.Count);
                    obj.GetComponent<BtnMgr>().BtnChoiceText = TalkChoices[randtext].reply;

                    TextMeshProUGUI choicetext = obj.transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>();
                    choicetext.text = TalkChoices[randtext].choice;
                    TalkChoices.RemoveAt(randtext);

                    obj.onClick.AddListener(() =>
                    {
                        // ItemLoad.Instance.SetLikeValue(TalkChoices[randtext].like, (int)Etalk);
                        Likenum.RemoveAt(randtext);

                        talk1 = obj.GetComponent<BtnMgr>().BtnChoiceText;
                        StartCoroutine(ETextTyping(txtTalk, talk1));

                        DeleteChilds();

                        Isque = false;
                    });
                }
                if (choiceId == (int)Etalk * 10)
                    istalk = false;
            }

            //yield return StartCoroutine(EwaitClick());
            //BackgroundManager.Instance.CharChange(talk.talkDatas[prog].Kang, talk.talkDatas[prog].Yang, talk.talkDatas[prog].Baek);
            //var Btn = EventSystem.current.currentSelectedGameObject;

            if (prog + 1 == talk.talkDatas.Count) continue;
            yield return StartCoroutine(EWaitInput());
        }
        //var talks = loader.LoadTalk();d
        //var choices = loader.LoadChoice();

        //TalkDatas talk = default;
        //ChoiceDatas choice = default;

        //talk = talks[talkId++];
        //for (int i = 0; i < talk.talkDatas.Count; i++)
        //{
        //    choice = choices[choiceId++];
        //    BackgroundManager.Instance.BackGroundChange(talk.talkDatas[i].background);
        //    txtName.text = talk.talkDatas[i].name.Replace("%PlayerName%", GameManager.Instance.layerName);
        //    txtTalk.text = talk.talkDatas[i].talk;
        //    yield return StartCoroutine(ETextTyping(txtTalk, talk.talkDatas[i].talk));

        //    for (int j = 0; j < choice.choiceDatas.Count; j++)
        //    {
        //        var obj = Instantiate(originChoiceText, rtrnChoiceParent);
        //        obj.text = $"{choice.choiceDatas[j].choice} ({choice.choiceDatas[j].like})";
        //    }

        //    if (i + 1 == talk.talkDatas.Count) continue;
        //    yield return StartCoroutine(EWaitInput());
        //}
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

    IEnumerator ETextTyping(Text text, string newString)
    {
        var wait = new WaitForSeconds(0.05f);

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
