using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
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

        StartCoroutine(ETalkEvent());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(ETalkEvent());
            print("Space");
        }
    }

    public IEnumerator ETalkEvent()
    {
        var talks = loader.LoadTalk();
        var choices = loader.LoadChoice();

        TalkDatas talk = default;
        ChoiceDatas choice = default;

        talk = talks[talkId++];
        print("es");
        for (int i = 0; i < talk.talkDatas.Count; i++)
        {
            print("dd");
            choice = choices[choiceId++];
            txtName.text = talk.talkDatas[i].name;
            txtTalk.text = talk.talkDatas[i].talk;
            yield return StartCoroutine(ETextTyping(txtTalk, talk.talkDatas[i].talk));

            for (int j = 0; j < choice.choiceDatas.Count; j++)
            {
                var obj = Instantiate(originChoiceText, rtrnChoiceParent);
                obj.text = $"{choice.choiceDatas[j].choice} ({choice.choiceDatas[j].like})";
            }

            if (i + 1 == talk.talkDatas.Count) continue;
            yield return StartCoroutine(EWaitClick());
        }

        yield return null;
    }

    IEnumerator EWaitClick()
    {
        var wait = new WaitForSeconds(0.001f);
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                print("Click");
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
            yield return wait;
        }

        yield return null;
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}
