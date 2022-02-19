using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public Button ResetOk;
    public List<GameObject> Items;

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
        Save save;
        int temp = 0;
        foreach (var savebtn in SaveBtn)
        {
            save = savebtn.GetComponent<Save>();
            save.savedata = saveData.savedatas[temp++];
            save.date.text = save.savedata.Date;
            savebtn.onClick.AddListener(() =>
            {
                Cursave = EventSystem.current.currentSelectedGameObject.GetComponent<Button>().GetComponent<Save>();
                if (savebtn.GetComponent<Save>().savedata.IsSave)
                    Savecheck.SetActive(true);
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

        GiftSaveData = ItemLoad.Instance.giftlist;
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
