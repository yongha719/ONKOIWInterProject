using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Save : MonoBehaviour, IPointerClickHandler
{
    public SaveData savedata;
    public SaveData resetdata = new SaveData();
    public SaveData GiftSaveData;
    public GameObject ResetCheck;
    public Button ResetOk;
    public Text date;
    void Start()
    {
        date.text = savedata.Date;
        GiftSaveData = ItemLoad.Instance.giftlist;

        ResetOk.onClick.AddListener(() =>
        {
            savedata = resetdata;
            date.text = "";
        });
    }

    void Update()
    {
        savedata.Date = date.text;
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            if (!savedata.IsSave && SceneManager.GetActiveScene().name != "Title")
            {
                date.text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss tt");
                savedata.IsSave = true;
                savedata.Savedata = TalkManager.Instance.talkprog.Talkprog;
                savedata.SaveLike = ItemLoad.Instance.Likes;
                savedata.kangGift = GiftSaveData.kangGift;
                savedata.yangGift = GiftSaveData.yangGift;
                savedata.baekGift = GiftSaveData.baekGift;
            }
        }
        else if (pointerEventData.button == PointerEventData.InputButton.Right)
        {
            if (savedata.IsSave)
                ResetCheck.SetActive(true);
        }
    }

}