using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Charchoice : MonoBehaviour
{
    public static Charchoice Instance { get; set; } = null;
    public Button[] Char;
    public GameObject[] Chars;

    public Button AniNext;
    public Button AniPrev;
    public int live = 0;

    public Text text;
    private void Awake()
    {
        foreach (var ch in Chars)
        {
            ch.SetActive(false);
        }
        Instance = this;
        AniNext.onClick.AddListener(() =>
        {
            foreach (var item in Chars)
            {
                int Max = default;
                if (item.activeSelf)
                {
                    Max = item.GetComponent<Live2DTest>().Max;
                    live++;
                }
                if (live > Max && Max != 0)
                    live = 0;
            }
        });
        AniPrev.onClick.AddListener(() =>
        {
            foreach (var item in Chars)
            {
                int Max = default;
                if (item.activeSelf)
                {
                    Max = item.GetComponent<Live2DTest>().Max;
                    live--;
                }
                if (live < 0 && Max != 0)
                    live = Max;
            }
        });
        Char[0].onClick.AddListener(() =>
        {
            live = 0;
            Chars[0].SetActive(true);
            Chars[1].SetActive(false);
            Chars[2].SetActive(false);
        });
        Char[1].onClick.AddListener(() =>
        {
            live = 0;
            Chars[0].SetActive(false);
            Chars[1].SetActive(true);
            Chars[2].SetActive(false);
        });
        Char[2].onClick.AddListener(() =>
        {
            live = 0;
            Chars[0].SetActive(false);
            Chars[1].SetActive(false);
            Chars[2].SetActive(true);
        });
    }
    void Start()
    {

    }

    void Update()
    {
        text.text = (live + 1).ToString();
    }
}
