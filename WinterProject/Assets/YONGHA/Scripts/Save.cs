using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
    public SaveData savedata;
    public Text date;

    void Start()
    {
        date.text = savedata.Date;
    }

    void Update()
    {
        savedata.Date = date.text;
    }
    
}