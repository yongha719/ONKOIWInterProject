using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public Button ExitBtn;

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
        IngameMenu.anchoredPosition = new Vector2(902.5f, 340);
        TalkSet();
        Save.SetActive(false);
        SettingObj.SetActive(false);

    }
    public void SliderValue()
    {
        if (LikeSlider != null)
            LikeSlider.value = ItemLoad.Instance.Likes[(int)TalkManager.Instance.Etalk - 1];
    }
    void Update()
    {
        SliderValue();
    }

    void TalkSet()
    {
        Charchoice[0].onClick.AddListener(() =>
        {
            TalkManager.Instance.Etalk = TalkChoice.Kang;
            BackgroundManager.Instance.Kangnum = 1;
        });
        Charchoice[1].onClick.AddListener(() =>
        {
            TalkManager.Instance.Etalk = TalkChoice.Yang;
            BackgroundManager.Instance.Yangnum = 1;
        });
        Charchoice[2].onClick.AddListener(() =>
        {
            TalkManager.Instance.Etalk = TalkChoice.Baek;
            BackgroundManager.Instance.Baeknum = 1;
        });
    }

}
