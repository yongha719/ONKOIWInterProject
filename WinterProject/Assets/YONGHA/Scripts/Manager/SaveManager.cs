using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{

    [SerializeField] List<Button> SaveBtn = new List<Button>();
    [SerializeField] GameObject Savepopup;
    [SerializeField] GameObject Savecheck;
    [SerializeField] Button Savequit;
    [SerializeField] Button Saveok;
    public Button ExitBtn;
    public List<GameObject> Items;

    List<bool> IsItem;
    Save Cursave;
    SaveData GiftSaveData;
    SaveDatas saveData;

    ITalkLoad loader;
    ITalkSave saver;
    void Start()
    {
        loader = new JsonLoader();
        saver = new JsonLoader();

        saveData = loader.LoadSaveDatas();
        GiftSaveData = ItemLoad.Instance.giftlist;
        Save save;
        int temp = 0;
        foreach (var savebtn in SaveBtn)
        {
            save = savebtn.GetComponent<Save>();
            save.savedata = saveData.savedatas[temp++];
            save.date.text = save.savedata.Date;
            savebtn.onClick.AddListener(() =>
            {
                if (!savebtn.GetComponent<Save>().savedata.IsSave)
                {
                    savebtn.GetComponent<Save>().date.text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss tt");
                    savebtn.GetComponent<Save>().savedata.IsSave = true;
                    savebtn.GetComponent<Save>().savedata.Savedata = TalkManager.Instance.talkprog.Talkprog;
                    savebtn.GetComponent<Save>().savedata.SaveLike = ItemLoad.Instance.Likes;
                    savebtn.GetComponent<Save>().savedata.kangGift = GiftSaveData.kangGift;
                    savebtn.GetComponent<Save>().savedata.yangGift = GiftSaveData.yangGift;
                    savebtn.GetComponent<Save>().savedata.baekGift = GiftSaveData.baekGift;
                }
                else
                {
                    Cursave = EventSystem.current.currentSelectedGameObject.GetComponent<Button>().GetComponent<Save>();
                    Savecheck.SetActive(true);
                }
            });
        }
        Savequit.onClick.AddListener(() =>
        {
            Save();
        });
        Saveok.onClick.AddListener(() =>
        {
            TalkProgress talkProgress = loader.LoadTalkData();
            talkProgress.Talkprog = Cursave.savedata.Savedata;
            saver.SaveData(Cursave.savedata);
            saver.SaveTalk(talkProgress);
        });
        ExitBtn.onClick.AddListener(() =>
        {

        });
    }
    void Update()
    {

    }
    void Save()
    {
        int temp = 0;
        foreach (var savebtn in SaveBtn)
        {
            saveData.savedatas[temp++] = savebtn.GetComponent<Save>().savedata;
        }
        saver.SaveDatas(saveData);
        Savepopup.SetActive(false);
    }
}
