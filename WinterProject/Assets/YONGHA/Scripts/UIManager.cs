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
    public void IngameMenuButton()
    {
        if (!OnMenu)
        {
            IngameMenu.DOAnchorPosX(710, 1);
            OnMenu = true;
        }
        else
        {
            IngameMenu.DOAnchorPosX(910, 1);
            OnMenu = false;
        }
    }
    public void SaveDate(Text text)
    {
        text.text = DateTime.Now.ToString(("yyyy-MM-dd HH:mm:ss tt"));
    }
    public void SaveWindow()
    {
        Save.SetActive(true);
    }
    void Start()
    {
        IngameMenu.anchoredPosition = new Vector2(910, 410);
        Save.SetActive(false);
    }

    void Update()
    {

    }
}
