using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

//                                      |
// ������ ( TalkManager ) ---> ITalkLoad | <--- JsonLoader ���� �ִ� ��
//                                      |

//
// ������ ( TalkManager ) ---> JsonLoader
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
        StartCoroutine(StoryEvent());
    }

    private void Update()
    {
    }
    void SetChar(int temp)
    {
        switch (Etalk)
        {
            case TalkChoice.Kang:

                break;
            case TalkChoice.Yang:

                break;
            case TalkChoice.Baek:

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
            choice = choices[(int)Etalk];

            txtName.text = talk.talkDatas[prog].name.Replace("%PlayerName%", GameManager.Instance.PlayerName);
            string talk1 = talk.talkDatas[prog].talk;
            txtTalk.text = talk1;

            yield return StartCoroutine(ETextTyping(txtTalk, talk1));

            for (int j = 0; j < choice.choiceDatas.Count; j++)
            {
                Choicetexts.Add(Choicebtn);
                Text choicetext = Choicebtn.transform.Find("Text").gameObject.GetComponent<Text>();
                choicetext.text = choice.choiceDatas[j].choice;
                var obj = Instantiate(Choicetexts[Random.Range(0, Choicetexts.Count)], rtrnChoiceParent);
           
            }
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
