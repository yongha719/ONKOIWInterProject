using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] Text timetext;
    Coroutine Gocorutine;
    public float time = 60;
    // Start is called before the first frame update
    void Start()
    {
        timetext.text = "" + time;
        Gocorutine = StartCoroutine(LoopTime());
    }

    IEnumerator LoopTime()
    {
        yield return new WaitForSeconds(1f);
        while(time > 0)
        {
            time -= 1;
            yield return new WaitForSeconds(1f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        timetext.text = "" + time;
        if(time == 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        if(GameClearManager.Inst.FindHide == 4)
        {
            StopCoroutine(Gocorutine);
        }
    }

   
}
