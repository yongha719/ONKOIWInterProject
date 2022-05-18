using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{

    [SerializeField] List<Button> SaveBtns;
    [SerializeField] GameObject Savepopup;
    [SerializeField] GameObject Savecheck;
    [SerializeField] Button Savequit;
    [SerializeField] Button Saveok;
    public Button ExitBtn;
    public Button ResetOk;

    Save Cursave;

    SaveDatas saveDatas;

    ITalkLoad loader;
    ITalkSave saver;

    void Start()
    {
        loader = new JsonLoader();
        saver = new JsonLoader();


        saveDatas = loader.LoadSaveDatas();
        Save save;
        int temp = 0;
        foreach (var savebtn in SaveBtns)
        {
            save = savebtn.GetComponent<Save>();
            save.savedata = saveDatas.savedatas[temp++];
            save.date.text = save.savedata.Date;
            savebtn.onClick.AddListener(() =>
            {
                //Cursave = EventSystem.current.currentSelectedGameObject.GetComponent<Button>().GetComponent<Save>();
                Cursave = EventSystem.current.currentSelectedGameObject.GetComponent<Save>();
                print(EventSystem.current.currentSelectedGameObject.GetComponent<Save>());
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
    }

    void Save()
    {
        int temp = 0;
        foreach (var savebtn in SaveBtns)
        {
            saveDatas.savedatas[temp++] = savebtn.GetComponent<Save>().savedata;
        }
        saver.SaveDatas(saveDatas);
        Savepopup.SetActive(false);
    }
}
