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

    List<Button> Choicetexts = new List<Button>();
    List<string> Textnum = new List<string>();
    List<int> Likenum = new List<int>();
    List<string> Replynum = new List<string>();

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
        SetChar();
    }
    void SetChar()
    {
        switch (Etalk)
        {
            case TalkChoice.Kang:
                choiceId = 0;
                break;
            case TalkChoice.Yang:
                choiceId = 9;
                break;
            case TalkChoice.Baek:
                choiceId = 19;
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
        SceneManager.LoadScene("Love(clone)");
        yield return null;
    }
    public IEnumerator ETalkEvent()
    {

        var talks = loader.LoadTalk();
        var choices = loader.LoadChoice();

        TalkDatas talk = talks[(int)Etalk];
        ChoiceDatas choice = default;

        for (prog = KtalkNum; prog < talk.talkDatas.Count; prog++)
        {

            txtName.text = talk.talkDatas[prog].name.Replace("%PlayerName%", GameManager.Instance.PlayerName);
            string talk1 = talk.talkDatas[prog].talk;
            txtTalk.text = talk1;

            yield return StartCoroutine(ETextTyping(txtTalk, talk1));

            choice = choices[choiceId++];

            for (int j = 0; j < choice.choiceDatas.Count; j++)
            {
                Choicetexts.Add(Choicebtn);

                Textnum.Add(choice.choiceDatas[j].choice);
                Likenum.Add(choice.choiceDatas[j].like);
                Replynum.Add(choice.choiceDatas[j].reply);
            }
            for (int j = 0; j < choice.choiceDatas.Count; j++)
            {
                int rand = Random.Range(0, Choicetexts.Count);
                var obj = Instantiate(Choicetexts[rand], rtrnChoiceParent);
                print("생성");
                Choicetexts.RemoveAt(rand);

                int randtext = Random.Range(0, Textnum.Count);
                obj.GetComponent<BtnMgr>().BtnChoiceText = Replynum[randtext];
                Replynum.RemoveAt(randtext);

                Text choicetext = obj.transform.Find("Text").gameObject.GetComponent<Text>();
                choicetext.text = Textnum[randtext];
                Textnum.RemoveAt(randtext);

                obj.onClick.AddListener(() =>
                {
                    ItemLoad.Instance.SetLikeValue(Likenum[randtext], (int)Etalk);
                    Likenum.RemoveAt(randtext);
                });
            }

            yield return StartCoroutine(EwaitClick());

            var Btn = EventSystem.current.currentSelectedGameObject;
            talk1 = Btn.GetComponent<BtnMgr>().BtnChoiceText;

            DeleteChilds();
            yield return StartCoroutine(ETextTyping(txtTalk, talk1));

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
    IEnumerator EwaitClick()
    {
        var wait = new WaitForSeconds(0.001f);
        while (true)
        {
            if (Input.GetMouseButtonDown(0) && EventSystem.current.currentSelectedGameObject.name == "btn(Clone)")
            {
                print("Click");
                yield return new WaitForSeconds(0.1f);
                yield break;
            }
            yield return wait;
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
