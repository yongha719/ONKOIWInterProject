using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Test
{
    public int[] a = new int[] { 1, 2, 3 };
}

public class JsonTest : MonoBehaviour
{
    public int prog;
    public int talkNum;
    public Button[] ConTalk;
    public Test test = new Test();
    ITalkLoad loader;
    ITalkSave saver;
    // Start is called before the first frame update
    void Start()
    {
        loader = new JsonLoader();
        saver = new JsonLoader();
        StartCoroutine(EJsonTest());
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            
        }

    }
    IEnumerator EJsonTest()
    {
        var wait = new WaitForSeconds(0.001f);
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                var talkprogs = loader.LoadData();
                TalkProgress talkprog = talkprogs;             
                talkNum = talkprog.Talkprog[0];
                yield return StartCoroutine(EWaitInput());

                talkprog.Talkprog[0] = prog;
                saver.SaveTalk(talkprog);
                foreach(var item in talkprog.Talkprog)
                    print(item);
                print("save");
            }
            yield return wait;
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

}
