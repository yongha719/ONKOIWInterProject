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

    public GameObject Save;

    [SerializeField] private GameObject SettingObj;

    public Slider LikeSlider;

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
        print("UI");
        IngameMenu.anchoredPosition = new Vector2(902.5f, 340);
        TalkSet();
        Save.SetActive(false);
        SettingObj.SetActive(false);
    }
    public void SliderValue()
    {
        switch ((int)TalkManager.Instance.Etalk)
        {
            case 1:
                LikeSlider.value = ItemLoad.Instance.chaeAhlike;
                break;
            case 2:
                LikeSlider.value = ItemLoad.Instance.seHwalike;
                break;
            case 3:
                LikeSlider.value = ItemLoad.Instance.gaYoonlike;
                break;
        }

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
