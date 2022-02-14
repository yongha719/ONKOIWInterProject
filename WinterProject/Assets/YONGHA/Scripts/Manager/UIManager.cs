using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public RectTransform IngameMenu;
    bool OnMenu = false;

    public GameObject Characters;
    public GameObject Save;

    [SerializeField] private GameObject SettingObj;

    

    public Button[] Charchoice;

    public void IngameMenuButton()
    {
        if (!OnMenu)
        {
            IngameMenu.DOAnchorPosX(702.5f, 1);
            OnMenu = true;
        }
        else
        {
            IngameMenu.DOAnchorPosX(902.5f, 1);
            OnMenu = false;
        }
    }

    void Start()
    {
        TalkSet();
        IngameMenu.anchoredPosition = new Vector2(902.5f, 410);
        Save.SetActive(false);
        SettingObj.SetActive(false);      
    }

    void Update()
    {

    }

    void TalkSet()
    {
        Charchoice[0].onClick.AddListener(() =>
        {
            TalkManager.Instance.Etalk = TalkChoice.Kang;
        });
        Charchoice[1].onClick.AddListener(() =>
        {
            TalkManager.Instance.Etalk = TalkChoice.Yang;
        });
        Charchoice[2].onClick.AddListener(() =>
        {
            TalkManager.Instance.Etalk = TalkChoice.Baek;
        });
    }

}
