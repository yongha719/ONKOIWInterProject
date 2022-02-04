using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//                                      |
// 쓰는쪽 ( TalkManager ) ---> ITalkLoad | <--- JsonLoader 서비스 주는 애
//                                      |

//
// 쓰는쪽 ( TalkManager ) ---> JsonLoader
//

public class TalkManager : MonoBehaviour
{
    public static TalkManager Instance { get; private set; } = null;
    public ITalkLoad loader;

    public List<ChoiceDatas> choiceDatas;

    [SerializeField] private Text txtName;
    [SerializeField] private Text txtTalk;
    [SerializeField] private RectTransform rtrnChoiceParent;
    [SerializeField] private Text originChoiceText;
    [SerializeField] private int talkId;
    [SerializeField] private int choiceId;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        loader = new JsonLoader();
        if (SceneManager.GetActiveScene().name != "Story")
            StartCoroutine(ETalkEvent());
        StartCoroutine(StoryEvent());
    }

    private void Update()
    {

    }

    public IEnumerator StoryEvent()
    {
        var talks = loader.LoadTalk();

        TalkDatas talk = default;

        talk = talks[talkId++];
        for (int i = 0; i < talk.talkDatas.Count; i++)
        {

            txtName.text = talk.talkDatas[i].name.Replace("%PlayerName%", GameManager.Instance.PlayerName).Replace("g", "g");
            txtTalk.text = talk.talkDatas[i].talk;

            yield return StartCoroutine(ETextTyping(txtTalk, talk.talkDatas[i].talk));

            if (i + 1 == talk.talkDatas.Count) continue;
            yield return StartCoroutine(EWaitInput());
        }
        yield return null;
    }
    public IEnumerator ETalkEvent()
    {
        var talks = loader.LoadTalk();
        var choices = loader.LoadChoice();

        TalkDatas talk = default;
        ChoiceDatas choice = default;

        talk = talks[talkId++];
        for (int i = 0; i < talk.talkDatas.Count; i++)
        {
            choice = choices[choiceId++];
            print(talk.talkDatas[i].background);
            BackgroundManager.Instance.BackGroundChange(talk.talkDatas[i].background);
            txtName.text = talk.talkDatas[i].name.Replace("%PlayerName%", GameManager.Instance.PlayerName).Replace("g", "g");
            txtTalk.text = talk.talkDatas[i].talk;
            yield return StartCoroutine(ETextTyping(txtTalk, talk.talkDatas[i].talk));

            for (int j = 0; j < choice.choiceDatas.Count; j++)
            {
                var obj = Instantiate(originChoiceText, rtrnChoiceParent);
                obj.text = $"{choice.choiceDatas[j].choice} ({choice.choiceDatas[j].like})";
            }

            if (i + 1 == talk.talkDatas.Count) continue;
            yield return StartCoroutine(EWaitInput());
        }

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
        var wait = new WaitForSeconds(0.1f);

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
