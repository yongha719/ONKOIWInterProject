using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    [SerializeField] List<Button> SaveBtn = new List<Button>();
    [SerializeField] GameObject Savecheck;
    [SerializeField] Button Savequit;
    SaveDatas saveDatas;
    ITalkSave saver;
    void Start()
    {
        saveDatas = new SaveDatas();
        saver = new JsonLoader();
        foreach (var savebtn in SaveBtn)
        {
            savebtn.onClick.AddListener(() =>
            {
                if (!savebtn.GetComponent<Save>().savedata.IsSave)
                {
                    Text text = savebtn.transform.Find("Date").GetComponent<Text>();

                    text.text = DateTime.Now.ToString(("yyyy-MM-dd HH:mm:ss tt"));

                    foreach (var prog in TalkManager.Instance.talkprog.Talkprog)
                        savebtn.GetComponent<Save>().savedata.Savedata.Add(prog);
                }
                else
                    Savecheck.SetActive(true);
            });
        }
        Savequit.onClick.AddListener(() =>
        {
            foreach (var savebtn in SaveBtn)
                saveDatas.savedatas.Add(savebtn.GetComponent<Save>().savedata);
            saver.SaveData(saveDatas);
        });
    }

    void Update()
    {

    }
}
