using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
    public SaveData savedata;
    Text date;

    void Start()
    {
        savedata = new SaveData();
        savedata.Savedata = null;
        savedata.IsSave = false;
        date = transform.Find("Date").GetComponent<Text>();
        print("Save √ ±‚»≠");
    }


    void Update()
    {  
        savedata.Date = date.text;
    }
}
